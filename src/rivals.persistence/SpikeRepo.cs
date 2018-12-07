using Microsoft.Extensions.Options;
using rivals.domain;
using rivals.domain.Configuration;
using System;
using System.Collections.Generic;

namespace rivals.persistence
{
    public class SpikeRepo : BaseRepo, ISpikeRepo
    {
        public IEnumerable<SpikeItem> GetSpikeItems()
        {
            return new List<SpikeItem>();
        }

        public SpikeRepo(IOptions<DatabaseSettings> dbOptions) : base(dbOptions)
        {

        }
    }
}
