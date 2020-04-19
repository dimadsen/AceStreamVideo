using System;
using Newtonsoft.Json;

namespace Parser.Models.Match
{
    public class Match
    {
        [JsonProperty(PropertyName = "teams")]
        public Team[] Teams { get; set; }
    }


}
