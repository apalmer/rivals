using System.Collections.Generic;
using System.Threading.Tasks;
using rivals.domain;

namespace rivals.persistence
{
    public interface ISpikeRepo
    {
        Task<IEnumerable<SpikeItem>> GetSpikeItems();

        Task<SpikeItem> GetSpikeItemById(string id);

        Task<System.Boolean> InsertSpikeItem(SpikeItem item);

        Task<System.Boolean> DeleteSpikeItem(string id);

        Task<System.Boolean> UpdateSpikeItem(SpikeItem  item);
    }
}