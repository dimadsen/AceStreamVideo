using Newtonsoft.Json;

namespace AceStream.Infrastructure.SportsRuParser.Tournament
{
    public class TeamInfo
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "logo")]
        public string Icon { get; set; }
    }
}
