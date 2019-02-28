﻿using System;
using System.Collections.Generic;
using Discord;
using EduardoBotv2.Models.Enums;

namespace EduardoBotv2.Models
{
    public class PaginatedMessage
    {
        public int CurrentIndex { get; set; }
        public int PreviousIndex { get; set; }
        public List<Embed> Embeds { get; set; }
        public TimeSpan Timeout { get; set; }
        public TimeoutBehaviour TimeoutBehaviour { get; set; }
    }
}