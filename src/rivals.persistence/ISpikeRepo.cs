using System.Collections.Generic;
using rivals.domain;

namespace rivals.persistence
{
    public interface ISpikeRepo
    {
        IEnumerable<SpikeItem> GetSpikeItems();
    }
}