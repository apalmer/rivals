using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rivals.domain.Game
{
    public class Player
    {
        [JsonProperty(PropertyName = "userName")]
        public String UserName { get; set; }

        [JsonProperty(PropertyName = "connectionId")]
        public String ConnectionID { get; set; }

        public Player(String userName, String connectionID)
        {
            UserName = userName;
            ConnectionID = connectionID;
        }
    }
}
