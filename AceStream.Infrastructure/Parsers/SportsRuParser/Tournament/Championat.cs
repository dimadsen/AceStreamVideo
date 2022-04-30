﻿using AceStream.Infrastructure.Parsers.SportsRuParser.Tournament;
using Newtonsoft.Json;

namespace AceStream.Infrastructure.SportsRuParser.Tournament
{
    public class Championat
    {
        [JsonProperty(PropertyName = "tag_id")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Country { get; set; }

        public Sport Sport { get; set; }

        [JsonProperty(PropertyName = "matches")]
        public MatchInfo[] Matches { get; set; }
    }
}
