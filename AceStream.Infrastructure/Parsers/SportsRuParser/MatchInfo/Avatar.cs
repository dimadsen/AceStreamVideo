using Newtonsoft.Json;

namespace AceStream.Infrastructure.Parsers.SportsRuParser.MatchInfo
{
    public class Avatar
    {
        [JsonProperty(PropertyName = "big_logo_mobile")]
        public string Icon { get; set; }
    }
}
