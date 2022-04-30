using System;
using Newtonsoft.Json;

namespace AceStream.Infrastructure.Parsers.SportsRuParser.MatchInfo
{
    public class Date
    {
        [JsonProperty(PropertyName = "full")]
        public string StartDate { get; set; }
    }
}
