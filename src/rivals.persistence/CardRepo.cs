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
        public CardRepo(IDocumentClient documentClient, IOptions<DatabaseSettings> dbOptions) : base(documentClient, dbOptions)
        {
        }
    }
}
