﻿using Discord;
using Newtonsoft.Json.Linq;
using EduardoBot.Common.Data;
using EduardoBot.Common.Utilities.Helpers;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EduardoBot.Services
{
    public class NewsService
    {
        public async Task GetNewsHeadlines(EduardoContext c, string source)
        {
            if (!Config.NEWS_SOURCES.Contains(source))
            {
                await c.Channel.SendMessageAsync($"**{source} is not a valid. Type `sources` to view available news sources**");
                return;
            }

            var request = WebRequest.Create(new Uri($"https://newsapi.org/v1/articles?source={source}&sortBy=top&apiKey={c.EduardoSettings.NewsApiKey}"));
            WebResponse response = await request.GetResponseAsync();

            string json;

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            JObject jResult = JObject.Parse(json);

            JArray jHeadlines = (JArray)jResult["articles"];
            List<EmbedFieldBuilder> headlines = new List<EmbedFieldBuilder>();

            var maxHeadlines = Math.Min(Config.MAX_HEADLINES, jHeadlines.Count - 1);
            for (var i = 0; i < maxHeadlines; i++)
            {
                var shorten = await GoogleHelper.ShortenUrlAsync(c.EduardoSettings.GoogleShortenerApiKey, jHeadlines[i]["url"].ToString());

                headlines.Add(new EmbedFieldBuilder()
                {
                    Name = jHeadlines[i]["title"].ToString(),
                    Value = $"{jHeadlines[i]["description"].ToString()}\n({shorten})"
                });
            }

            EmbedBuilder builder = new EmbedBuilder()
            {
                Author = new EmbedAuthorBuilder()
                {
                    IconUrl = @"http://shmector.com/_ph/18/412122157.png",
                    Name = $"Latest News from {source.Replace('-', ' ').ToUpper()}"
                },
                Color = Color.Blue,
                ThumbnailUrl = jResult["articles"][0]["urlToImage"].ToString(),
                Fields = headlines,
                Footer = new EmbedFooterBuilder()
                {
                    Text = "News via newsapi.org",
                    IconUrl = @"https://pbs.twimg.com/profile_images/815237522641092609/6IeO3WLV.jpg"
                }
            };

            await c.Channel.SendMessageAsync("", false, builder.Build());
        }

        public async Task ShowNewsSources(EduardoContext c)
        {
            await c.Channel.SendMessageAsync($"**Available sources for the news command are:**\n{string.Join(", ", Config.NEWS_SOURCES)}");
        }
    }
}