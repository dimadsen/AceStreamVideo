using System;
using Newtonsoft.Json;

namespace AceStream.Infrastructure.SportsRuParser.Tournament
{
    public class Team
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "logo")]
        public string Icon { get; set; }
    }
}
