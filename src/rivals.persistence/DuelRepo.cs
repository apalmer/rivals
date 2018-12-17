using Microsoft.Azure.Documents;
using Microsoft.Extensions.Options;
using rivals.domain.Configuration;
using rivals.domain.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.persistence
{
    public class DuelRepo : BaseRepo<Duel>
    {
        public DuelRepo(IDocumentClient documentClient, IOptions<DatabaseSettings> dbOptions) : base(documentClient, dbOptions)
        {
        }
    }
}
