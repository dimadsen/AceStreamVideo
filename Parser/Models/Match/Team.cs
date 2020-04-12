using System;
using Newtonsoft.Json;

namespace Parser.Models.Match
{
    public class Team
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "icon80x80")]
        public string Icon { get; set; }

        public Player[] Players { get; set; }

        public Player[] ReservePlayers { get; set; }
    }
}
