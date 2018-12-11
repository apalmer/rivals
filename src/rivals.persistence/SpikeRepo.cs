using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using rivals.domain;
using rivals.domain.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Linq;

namespace rivals.persistence
{
    public class SpikeRepo : BaseRepo, ISpikeRepo
    {
        public async Task<IEnumerable<SpikeItem>> GetSpikeItems()
        {
            List<SpikeItem> results = null;
            try
            {
                var collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID);
                var documentQuery = Client.CreateDocumentQuery<SpikeItem>(collectionUri,
                    $"SELECT * FROM StrivingRivalsCollection c",
                    new FeedOptions()
                    {
                        EnableCrossPartitionQuery = true,
                        MaxItemCount = 100,
                    }).AsDocumentQuery<SpikeItem>();
                while (documentQuery.HasMoreResults)
                {
                    results = new List<SpikeItem>();
                    foreach (var spikeItem in await documentQuery.ExecuteNextAsync<SpikeItem>())
                    {
                        results.Add(spikeItem);
                    }
                }
            }
            catch (DocumentClientException e)
            {
                throw;
            }

            return results;
        }

        public async Task<SpikeItem> GetSpikeItemById(string id)
        {
            SpikeItem result = null;
            try
            {
                Document document = await Client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseID, CollectionID, id));
                result = (SpikeItem)(dynamic)document;
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

        public async Task<System.Boolean> InsertSpikeItem(SpikeItem item)
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

        public async Task<System.Boolean> DeleteSpikeItem(string id)
        {
            var deleted = false;

            try
            {

                var documentToDeleteUri = UriFactory.CreateDocumentUri(DatabaseID, CollectionID, id);

                ResourceResponse<Document> deletedDocumentResponse = await Client.DeleteDocumentAsync(
                    documentToDeleteUri);

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

        public async Task<System.Boolean> UpdateSpikeItem(SpikeItem item)
        {
            var updated = false;

            try
            {
                var documentToUpdateUri = UriFactory.CreateDocumentUri(DatabaseID, CollectionID, item.ID);

                ResourceResponse<Document> updatedDocumentResponse = await Client.ReplaceDocumentAsync(
                    documentToUpdateUri,
                    item);

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

        public SpikeRepo(IOptions<DatabaseSettings> dbOptions) : base(dbOptions)
        {
        }
    }
}
