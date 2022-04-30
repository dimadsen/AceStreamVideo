using System;
using Newtonsoft.Json;

namespace AceStream.Infrastructure.Parsers.SportsRuParser.Match
{
    public class Flag
    {
        [JsonProperty(PropertyName = "flag_country")]
        public string Country { get; set; }
    }
}
