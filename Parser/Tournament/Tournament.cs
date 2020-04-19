﻿using Newtonsoft.Json;

namespace Parser.Tournament
{
    public class Tournament
    {
        [JsonProperty(PropertyName = "teaser")]
        public Teaser Teaser { get; set; }
    }

    public class Teaser
    {
        [JsonProperty(PropertyName = "tournaments")]
        public Championat[] Championats { get; set; }
    }
}
