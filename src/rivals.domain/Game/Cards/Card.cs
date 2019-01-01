using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.domain.Game.Cards
{
    public class Card : Persistable
    {
        [JsonProperty(PropertyName = "movement")]
        public Movement Movement { get; set; }

        [JsonProperty(PropertyName = "damage")]
        public Damage Damage { get; set; }

        [JsonProperty(PropertyName = "defense")]
        public Defense Defense { get; set; }
    }
}
