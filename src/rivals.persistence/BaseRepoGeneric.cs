using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using rivals.domain.Spike;
using rivals.domain.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Linq;
using rivals.domain;

namespace rivals.persistence
{
    public class BaseRepo<T> : BaseRepo, IRepo<T> where T : Persistable, new()
    {
        public async Task<IEnumerable<T>> GetAll()
        {
            List<T> results = null;
            try
            {
                var collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID);
                var documentQuery = Client.CreateDocumentQuery<T>(collectionUri,
                    $"SELECT * FROM StrivingRivalsCollection c WHERE c.documentType = '{new T().DocumentType}'",
                    new FeedOptions()
                    {
                        EnableCrossPartitionQuery = true,
                        MaxItemCount = 100,
                    }).AsDocumentQuery<T>();
                while (documentQuery.HasMoreResults)
                {
                    results = new List<T>();
                    foreach (var item in await documentQuery.ExecuteNextAsync<T>())
                    {
                        results.Add(item);
                    }
                }
            }
            catch (DocumentClientException e)
            {
                throw;
            }

            return results;
        }

        public async Task<T> GetById(string id)
        {
            T result = null;
            try
            {
                Document document = await Client.ReadDocumentAsync(
                    UriFactory.CreateDocumentUri(DatabaseID, CollectionID, id),
                    new RequestOptions() {
                        PartitionKey = new PartitionKey(PartitionKey)
                    }
                );
                result = (T)(dynamic)document;
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

        public async Task<System.Boolean> Insert(T item)
        {
            var inserted = false;

            try
            {
                var collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID);
                var documentResponse = await Client.CreateDocumentAsync(collectionUri, item);

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

        public async Task<System.Boolean> Delete(string id)
        {
            var deleted = false;

            try
            {

                var documentToDeleteUri = UriFactory.CreateDocumentUri(DatabaseID, CollectionID, id);

                ResourceResponse<Document> deletedDocumentResponse = await Client.DeleteDocumentAsync(
                    documentToDeleteUri,
                    new RequestOptions() {
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

        public async Task<System.Boolean> Update(T item)
        {
            var updated = false;

            try
            {
                var documentToUpdateUri = UriFactory.CreateDocumentUri(DatabaseID, CollectionID, item.ID);

                ResourceResponse<Document> updatedDocumentResponse = await Client.ReplaceDocumentAsync(
                    documentToUpdateUri,
                    item,
                    new RequestOptions() {
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

        public BaseRepo(IDocumentClient documentClient, IOptions<DatabaseSettings> dbOptions) : base(documentClient, dbOptions)
        {
        }
    }
}
