using Newtonsoft.Json;

namespace AceStream.Core.Parser.Tournament
{
    public class Championat
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public string Country { get; set; }

        [JsonProperty(PropertyName = "matches")]
        public MatchInfo[] Matches { get; set; }
    }
}
