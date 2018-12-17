using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using rivals.domain.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.persistence
{
    public abstract class BaseRepo
    {
        protected IDocumentClient Client { get; set; }
        protected String DatabaseID { get; set; }
        protected String CollectionID { get; set; }
        protected String PartitionKey { get; set; }

        public BaseRepo(IDocumentClient documentClient, IOptions<DatabaseSettings> dbOptions)
        {
            Client = documentClient;
            var options = dbOptions.Value;
            DatabaseID = options.DatabaseID;
            CollectionID = options.CollectionID;
            PartitionKey = options.PartitionKey;
        }
    }
}
