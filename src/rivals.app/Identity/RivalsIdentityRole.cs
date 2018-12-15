using AspNetCore.Identity.DocumentDb;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rivals.app.Identity
{
    public class RivalsIdentityRole : DocumentDbIdentityRole
    {
        [JsonProperty(PropertyName = "region")]
        public String Region { get { return "Central US"; } }
    }
}
