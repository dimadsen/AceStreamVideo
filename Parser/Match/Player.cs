using System;
using Newtonsoft.Json;

namespace Parser.Models.Match
{
    public class Player
    {
        public string Number { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "flags")]
        public Flag[] Flag { get; set; }

        /// <summary>
        /// Вышел с замены?
        /// </summary>
        [JsonProperty(PropertyName = "replacement")]
        public bool IsReplacement { get; set; }
    }

    public class Flag
    {
        [JsonProperty(PropertyName = "flag_country")]
        public string Country { get; set; }
    }
}
