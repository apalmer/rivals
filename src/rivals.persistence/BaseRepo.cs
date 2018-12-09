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
        private DatabaseSettings DatabaseSettings { get; set; }
        protected DocumentClient Client { get; set; }
        protected String DatabaseID { get; set; }
        protected String CollectionID { get; set; }

        public BaseRepo(IOptions<DatabaseSettings> dbOptions)
        {
            DatabaseSettings = dbOptions.Value;
            var endpoint = new Uri(DatabaseSettings.EndpointUrl);
            var passKey = DatabaseSettings.PassKey;

            DatabaseID = "StrivingRivalsDB";
            CollectionID = "StrivingRivalsCollection";

            Client = new DocumentClient(endpoint, passKey);
        }
    }
}
