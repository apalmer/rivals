using rivals.domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rivals.persistence
{
    public interface IRepo<T> where T : Persistable, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<System.Boolean> Insert(T item);
        Task<System.Boolean> Delete(string id);
        Task<System.Boolean> Update(T item);
    }
}