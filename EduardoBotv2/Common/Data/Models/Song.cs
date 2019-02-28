﻿using Discord;
using System;

namespace EduardoBotv2.Common.Data.Models
{
    public class Song
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Url { get; set; }
        public string StreamUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public IGuildUser RequestedBy { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public TimeSpan TimePassed => StartTime.HasValue ? DateTimeOffset.Now - StartTime.Value : TimeSpan.FromSeconds(0);
    }
}