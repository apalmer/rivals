using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.domain.Game.Cards
{
    public class Movement
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type")]
        public MovementType Type { get; set; }

        [JsonProperty(PropertyName = "magnitude")]
        public Nullable<Int32> Magnitude { get; set; }
    }
}
