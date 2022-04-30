using System;
using Newtonsoft.Json;

namespace AceStream.Infrastructure.Parsers.SportsRuParser.Tournament
{
    public class Date
    {
        [JsonProperty(PropertyName = "full")]
        public DateTime StartDate { get; set; }
    }
}
