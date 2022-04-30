using AceStream.Infrastructure.Parsers.SportsRuParser.MatchInfo;
using Newtonsoft.Json;

namespace AceStream.Infrastructure.SportsRuParser.MatchInfo
{
    public class FullMatchInfo
    {
        [JsonProperty(PropertyName = "start_time")]
        public Date Date { get; set; }

        [JsonProperty(PropertyName = "state_name")] 
        public string StatusName { get; set; }

        public string Time { get; set; }

        public string Score { get; set; }

        [JsonProperty(PropertyName = "first_team")]
        public Team Home { get; set; }

        [JsonProperty(PropertyName = "second_team")]
        public Team Visitor { get; set; }

        public Stadium Stadium { get; set; }

        [JsonProperty(PropertyName = "tv")]
        public Channel[] Channels { get; set; }
    }
}
