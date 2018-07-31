﻿using System;
using Discord;
using EduardoBotv2.Common.Data;
using EduardoBotv2.Common.Data.Enums;
using EduardoBotv2.Common.Extensions;
using EduardoBotv2.Common.Data.Models;
using EduardoBotv2.Common.Utilities.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.YouTube.v3.Data;

namespace EduardoBotv2.Services
{
    public class YouTubeModuleService
    {
        public async Task SearchYouTube(EduardoContext c, string searchQuery = null)
        {
            if (searchQuery != null)
            {
                SearchListResponse searchVideosResponse = await GoogleHelper.SearchYouTubeAsync(c.EduardoSettings.GoogleYouTubeApiKey, "snippet", searchQuery, 5, YouTubeRequestType.Video);
                
                List<Embed> pageEmbeds = searchVideosResponse.Items.Select((t, i) => new EmbedBuilder
                {
                    Color = Color.Red,
                    Title = t.Snippet.Title,
                    Description = t.Snippet.Description,
                    ThumbnailUrl = t.Snippet.Thumbnails.Default__.Url,

                    Footer = new EmbedFooterBuilder
                    {
                        IconUrl = @"https://seeklogo.com/images/Y/youtube-icon-logo-521820CDD7-seeklogo.com.png",
                        Text = $"Page {i + 1}"
                    },
                    Url = $"http://youtu.be/{t.Id.VideoId}"
                }.Build()).ToList();

                await c.SendPaginatedMessageAsync(new PaginatedMessage
                {
                    Embeds = pageEmbeds,
                    Timeout = TimeSpan.FromSeconds(Config.PAGINATION_TIMEOUT_SECONDS),
                    TimeoutBehaviour = TimeoutBehaviour.Delete
                });
            }
        }
    }
}