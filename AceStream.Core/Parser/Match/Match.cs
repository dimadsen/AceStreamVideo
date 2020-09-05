using System;
using Newtonsoft.Json;

namespace AceStream.Core.Parser.Match
{
    public class Match
    {
        [JsonProperty(PropertyName = "teams")]
        public Team[] Teams { get; set; }
    }
}
