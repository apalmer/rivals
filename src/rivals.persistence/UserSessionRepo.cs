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
    public class UserSessionRepo : BaseRepo
    {
        public async Task<IEnumerable<UserSession>> GetUserSessions()
        {
            List<UserSession> results = null;
            try
            {
                var collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID);
                var documentQuery = Client.CreateDocumentQuery<UserSession>(collectionUri,
                    $"SELECT * FROM StrivingRivalsCollection c WHERE c.documentType = 'rivals.domain.Session.UserSession'",
                    new FeedOptions()
                    {
                        EnableCrossPartitionQuery = true,
                        MaxItemCount = 100,
                    }).AsDocumentQuery<UserSession>();
                while (documentQuery.HasMoreResults)
                {
                    results = new List<UserSession>();
                    foreach (var UserSession in await documentQuery.ExecuteNextAsync<UserSession>())
                    {
                        results.Add(UserSession);
                    }
                }
            }
            catch (DocumentClientException e)
            {
                throw;
            }

            return results;
        }

        public async Task<UserSession> GetUserSessionById(string id)
        {
            UserSession result = null;
            try
            {
                Document document = await Client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseID, CollectionID, id),
                    new RequestOptions()
                    {
                        PartitionKey = new PartitionKey(PartitionKey)
                    });
                result = (UserSession)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return result;
        }

        public async Task<System.Boolean> InsertUserSession(UserSession item)
        {
            var inserted = false;

            try
            {
                var collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID);
                var documentResponse = await Client.CreateDocumentAsync(collectionUri, item//,
                    //new RequestOptions()
                    //{
                    //    PartitionKey = new PartitionKey(PartitionKey)
                    //}
                );

                if (documentResponse.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    inserted = true;
                }
            }
            catch (DocumentClientException e)
            {

                throw;
            }

            return inserted;
        }

        public async Task<System.Boolean> DeleteUserSession(string id)
        {
            var deleted = false;

            try
            {

                var documentToDeleteUri = UriFactory.CreateDocumentUri(DatabaseID, CollectionID, id);

                ResourceResponse<Document> deletedDocumentResponse = await Client.DeleteDocumentAsync(
                    documentToDeleteUri,
                    new RequestOptions()
                    {
                        PartitionKey = new PartitionKey(PartitionKey)
                    });

                if (deletedDocumentResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    deleted = true;
                }
            }
            catch (DocumentClientException e)
            {
                throw;
            }

            return deleted;
        }

        public async Task<System.Boolean> UpdateUserSession(UserSession item)
        {
            var updated = false;

            try
            {
                var documentToUpdateUri = UriFactory.CreateDocumentUri(DatabaseID, CollectionID, item.ID);

                ResourceResponse<Document> updatedDocumentResponse = await Client.ReplaceDocumentAsync(
                    documentToUpdateUri,
                    item,
                    new RequestOptions()
                    {
                        PartitionKey = new PartitionKey(PartitionKey)
                    });

                if (updatedDocumentResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    updated = true;
                }
            }
            catch (DocumentClientException e)
            {
               throw;
            }

            return updated;
        }

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
                    await DeleteUserSession(itemToDelete);
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
