using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.domain
{
    public abstract class Persistable
    {
        [JsonProperty(PropertyName = "id")]
        public String ID { get; set; }
        [JsonProperty(PropertyName = "documentType")]
        public String DocumentType { get { return GetType().FullName; } }
        [JsonProperty(PropertyName = "region")]
        public String Region { get { return "Central US"; } }
    }
}
