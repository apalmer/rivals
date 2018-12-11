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
        public String DocumentType { get; set; }
        public String Region { get; set; }

        public void SetDefaultProperties()
        {
            DocumentType = this.ToString();
            Region = "Central US";
        }
    }
}
