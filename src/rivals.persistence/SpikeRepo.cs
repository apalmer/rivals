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
            return await GetMultipleSpikeItems();
        }

        private async Task<IEnumerable<SpikeItem>> GetSingleSpikeItem()
        {
            SpikeItem result = null;
            var id = "hh";
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

            return new List<SpikeItem>() { result };
        }

        private async Task<IEnumerable<SpikeItem>> GetMultipleSpikeItems()
        {
            List<SpikeItem> results = new List<SpikeItem>();
            try
            {
                var collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID);
                var documentQuery = Client.CreateDocumentQuery<SpikeItem>(collectionUri,
                    $"SELECT * FROM StrivingRivalsCollection c WHERE c.id = 'First'",
                    new FeedOptions()
                    {
                        EnableCrossPartitionQuery = true,
                        MaxItemCount = 100,
                    }).AsDocumentQuery<SpikeItem>();
                while (documentQuery.HasMoreResults)
                {
                    foreach (var spikeItem in await documentQuery.ExecuteNextAsync<SpikeItem>())
                    {
                        results.Add(spikeItem);
                    }
                }
            }
            catch (Exception e)
            {
                var x = e.Message;
            }

            return results;
        }

        public SpikeRepo(IOptions<DatabaseSettings> dbOptions) : base(dbOptions)
        {
        }
    }
}
