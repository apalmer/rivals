using rivals.domain.Spike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rivals.app.Models
{
    public class SpikeCollectionModel
    {
        public IEnumerable<SpikeItem> Items { get; set; }
    }
}
