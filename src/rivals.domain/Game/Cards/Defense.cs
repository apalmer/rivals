using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.domain.Game.Cards
{
    public class Defense
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type")]
        public DefenseType Type { get; set; }

        [JsonProperty(PropertyName = "magnitude")]
        public Nullable<Int32> Magnitude { get; set; }
    }  
}
