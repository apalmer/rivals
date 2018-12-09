using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.domain
{
    public abstract class Persistable
    {
        public String ID { get; set; }
        public String EntityType { get; set; }
        public String Region { get; set; }

        public Persistable()
        {
            EntityType = this.ToString();
            Region = "East US";
        }
    }
}
