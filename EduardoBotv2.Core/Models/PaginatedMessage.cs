﻿using System;
using System.Collections.Generic;
using Discord;

namespace EduardoBotv2.Core.Models
{
    public class PaginatedMessage
    {
        public int CurrentIndex { get; set; }

        public int PreviousIndex { get; set; }

        public List<Embed> Embeds { get; set; }

        public TimeSpan Timeout { get; set; }

        public TimeoutBehaviour TimeoutBehaviour { get; set; }

        public string Text { get; set; }

        public List<PaginatedMessageReaction> Reactions { get; set; } = new List<PaginatedMessageReaction>();

        public Action TimeoutCallback { get; set; }

        public static readonly PaginatedMessage Default = new PaginatedMessage
        {
            Timeout = TimeSpan.FromSeconds(Constants.PAGINATION_TIMEOUT_SECONDS),
            TimeoutBehaviour = TimeoutBehaviour.Default
        };
    }
}