using System;
using Newtonsoft.Json;

namespace AceStream.Infrastructure.Parser.Match
{
    public class ParserTeam
    {
        public string Name { get; set; }

        public string Goals { get; set; }

        [JsonProperty(PropertyName = "big_logo")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "players")]
        public ParserPlayer[] Startings { get; set; }

        [JsonProperty(PropertyName = "reserve")]
        public ParserPlayer[][] Substitutes { get; set; }

    }
}
