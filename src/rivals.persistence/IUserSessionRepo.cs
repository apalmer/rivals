using rivals.domain.Session;
using System.Threading.Tasks;

namespace rivals.persistence
{
    public interface IUserSessionRepo : IRepo<UserSession>
    {
        Task<bool> TerminateSessionsbyUserName(string userName);
    }
}