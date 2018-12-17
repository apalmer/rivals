using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using rivals.domain.Session;
using rivals.domain.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Linq;

namespace rivals.persistence
{
    public class UserSessionRepo : BaseRepo<UserSession>, IUserSessionRepo
    {
        public async Task<System.Boolean> TerminateSessionsbyUserName(string userName)
        {
            var terminated = false;

            try
            {
                var collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID);
                var documentQuery = Client.CreateDocumentQuery<UserSession>(collectionUri,
                    $"SELECT * FROM StrivingRivalsCollection c WHERE c.documentType = 'rivals.domain.Session.UserSession' AND c.UserName = '{userName}'",
                    new FeedOptions()
                    {
                        EnableCrossPartitionQuery = true,
                        MaxItemCount = 100,
                    }).AsDocumentQuery<UserSession>();

                var itemsToDelete = new List<String>();
                while (documentQuery.HasMoreResults)
                {
                    foreach (var UserSession in await documentQuery.ExecuteNextAsync<UserSession>())
                    {
                        itemsToDelete.Add(UserSession.ID);
                    }
                }

                foreach (var itemToDelete in itemsToDelete)
                {
                    await Delete(itemToDelete);
                }

                terminated = true;
            }
            catch (DocumentClientException e)
            {
                throw;
            }

            return terminated;
        }

        public UserSessionRepo(IDocumentClient documentClient, IOptions<DatabaseSettings> dbOptions) : base(documentClient, dbOptions)
        {
        }
    }
}
