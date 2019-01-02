using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using rivals.domain.Spike;
using rivals.domain.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Linq;
using rivals.domain.Game.Cards;

namespace rivals.persistence
{
    public class CardRepo : BaseRepo<Card>, ICardRepo
    {
        public async Task<Card> GetByName(String cardName)
        {
            Card result = new Card();
            try
            {
                var collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID);
                var query = $"SELECT * FROM StrivingRivalsCollection c WHERE c.documentType = '{result.DocumentType}' AND name = '{cardName}'";
                var feedOptions = new FeedOptions()
                {
                    EnableCrossPartitionQuery = true,
                    MaxItemCount = 100,
                };

                var documentQuery = Client
                    .CreateDocumentQuery<Card>(collectionUri, query, feedOptions)
                    .AsDocumentQuery<Card>(); 
                  
                while (documentQuery.HasMoreResults)
                {
                    foreach (var card in await documentQuery.ExecuteNextAsync<Card>())
                    {
                        result = card;
                    }
                }
            }
            catch (DocumentClientException e)
            {
                throw;
            }

            return result;
        }

        public CardRepo(IDocumentClient documentClient, IOptions<DatabaseSettings> dbOptions) : base(documentClient, dbOptions)
        {

        }
    }
}
