﻿using Newtonsoft.Json;

namespace EduardoBot.Common.Data.Models
{
    public class Pokemon
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sprites")]
        public PokemonSprite Sprites { get; set; }
    }
}