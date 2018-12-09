using System.Collections.Generic;
using System.Threading.Tasks;
using rivals.domain;

namespace rivals.persistence
{
    public interface ISpikeRepo
    {
        Task<IEnumerable<SpikeItem>> GetSpikeItems();
    }
}