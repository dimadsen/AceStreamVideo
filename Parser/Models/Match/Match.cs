using Newtonsoft.Json;

namespace Parser.Models.Match
{
    public class Match
    {
        public string Date { get; set; }

        public string HomeScore { get; set; }

        [JsonProperty(PropertyName = "guestScore")]
        public string VisitorScore { get; set; }

        [JsonProperty(PropertyName = "statusName")] 
        public string Status { get; set; }

        public string Score { get; set; }

        [JsonProperty(PropertyName = "homeCommand")]
        public Team HomeTeam { get; set; }

        [JsonProperty(PropertyName = "guestCommand")]
        public Team VisitorTeam { get; set; }
    }
}
