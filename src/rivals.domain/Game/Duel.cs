using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rivals.domain.Game
{
    public class Duel
    {
        [JsonProperty(PropertyName = "duelId")]
        public String DuelID { get; set; }

        private Player _challenger;
        private Player _challenged;

        public Duel(Player challenger, Player challenged)
        {
            DuelID = Guid.NewGuid().ToString();
            _challenger = challenger;
            _challenged = challenged;
        }
    }
}
