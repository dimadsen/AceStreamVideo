using Newtonsoft.Json;

namespace Parser.Models.MatchInfo
{
    public class MatchInfo
    {
        [JsonProperty(PropertyName = "start_time")]
        public Date Date { get; set; }

        [JsonProperty(PropertyName = "status_name")] 
        public string Status { get; set; }

        public string Score { get; set; }

        [JsonProperty(PropertyName = "first_team")]
        public Team Home { get; set; }

        [JsonProperty(PropertyName = "second_team")]
        public Team Visitor { get; set; }

        public Stadium Stadium { get; set; }
    }

    public class Date
    {
        [JsonProperty(PropertyName = "full")]
        public string StartDate { get; set; }
    }

    public class Team
    {
        public string Name { get; set; }

        public Avatar Avatar { get; set; }
    }

    public class Avatar
    {
        [JsonProperty(PropertyName = "big_logo_mobile")]
        public string Icon { get; set; }
    }

    public class Stadium
    {
        public string Name { get; set; }
    }
}
