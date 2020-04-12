using System;
using Newtonsoft.Json;

namespace Parser.Models.Match
{
    public class Player
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "originName")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "originFlag50x50")]
        public string Flag { get; set; }

        public Info Info { get; set; }
    }

    public class Info
    {
        public string Number { get; set; }

        public string OrderChange { get; set; }
        
        /// <summary>
        /// Вышел на поле (для резервных игроков).
        /// У игроков основного состава всегда false
        /// </summary>
        public bool IsOrderChanged()
        {
            return OrderChange == "1";
        }
    }
}
