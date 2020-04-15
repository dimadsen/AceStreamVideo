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
    }

    public class Date
    {
        [JsonProperty(PropertyName = "full")]
        public string StartDate { get; set; }
    }
}
