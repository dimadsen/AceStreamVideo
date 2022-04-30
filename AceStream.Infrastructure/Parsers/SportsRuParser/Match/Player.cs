﻿using System;
using AceStream.Infrastructure.Parsers.SportsRuParser.Match;
using Newtonsoft.Json;

namespace AceStream.Infrastructure.SportsRuParser.Match
{
    public class Player
    {
        public string Number { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "flags")]
        public Flag[] Flag { get; set; }

        /// <summary>
        /// Был заменён?
        /// </summary>
        [JsonProperty(PropertyName = "replacement")]
        public bool IsReplacement { get; set; }

        /// <summary>
        /// Имя и минута кем заменён
        /// </summary>
        [JsonProperty(PropertyName = "replacement_comment")]
        public string Replacement { get; set; }

        /// <summary>
        /// Имя и минута кого заменил
        /// </summary>
        [JsonProperty(PropertyName = "replaced_comment")]
        public string Replaced { get; set; }
    }    
}
