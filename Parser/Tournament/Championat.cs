using Newtonsoft.Json;

namespace Parser.Tournament
{
    public class Championat
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        [JsonProperty(PropertyName = "matches")]
        public MatchInfo[] Matches { get; set; }
    }
}
