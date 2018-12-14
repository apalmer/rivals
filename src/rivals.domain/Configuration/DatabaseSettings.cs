using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.domain.Configuration
{
    public class DatabaseSettings
    {
        public String DatabaseID { get; set; }
        public String CollectionID { get; set; }
        public String PartitionKey { get; set; }
    }
}
