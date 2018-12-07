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
        DatabaseSettings DatabaseSettings { get; set; }
        DocumentClient Client { get; set; }

        public BaseRepo(IOptions<DatabaseSettings> dbOptions)
        {
            DatabaseSettings = dbOptions.Value;
            var endpoint = new Uri(DatabaseSettings.EndpointUrl);
            var passKey = DatabaseSettings.PassKey;

            var client = new DocumentClient(endpoint, passKey);
        }
    }
}
