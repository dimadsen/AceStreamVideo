using System;
using Newtonsoft.Json;

namespace Parser.Tournament
{
    public class MatchInfo
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public Date Date { get; set; }

        public Status Status { get; set; }

        public string Score { get; set; }

        [JsonProperty(PropertyName = "first_team")]
        public Team Home { get; set; }

        [JsonProperty(PropertyName = "second_team")]
        public Team Visitor { get; set; }
    }

    public class Date
    {
        [JsonProperty(PropertyName = "full")]
        public DateTime StartDate { get; set; }
    }

    public class Status
    {
        public string Name { get; set; }
    }

}
