using System;
using Newtonsoft.Json;

namespace Engine.Models
{
    public class Url
    {
        [JsonProperty(PropertyName = "playback_url")]
        public string PlayBackUrl { get; set; }
    }
}
