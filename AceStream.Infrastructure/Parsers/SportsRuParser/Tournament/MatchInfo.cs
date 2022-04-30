using System;
using AceStream.Infrastructure.Parsers.SportsRuParser.Tournament;
using Newtonsoft.Json;

namespace AceStream.Infrastructure.SportsRuParser.Tournament
{
    public class MatchInfo
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public Date Date { get; set; }

        public Status Status { get; set; }

        public string Score { get; set; }

        [JsonProperty(PropertyName = "first_team")]
        public TeamInfo Home { get; set; }

        [JsonProperty(PropertyName = "second_team")]
        public TeamInfo Visitor { get; set; }
    }  
}
