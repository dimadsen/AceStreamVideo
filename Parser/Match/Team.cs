using System;
using Newtonsoft.Json;

namespace Parser.Models.Match
{
    public class Team
    {
        public string Name { get; set; }

        public string Goals { get; set; }

        [JsonProperty(PropertyName = "big_logo")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "players")]
        public Player[] Startings { get; set; }

        [JsonProperty(PropertyName = "reserve")]
        public Player[][] Substitutes { get; set; }
    }
}
