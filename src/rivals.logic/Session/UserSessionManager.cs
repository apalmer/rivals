using rivals.domain.Session;
using rivals.persistence;
using System;
using System.Threading.Tasks;

namespace rivals.logic.Session
{
    public class UserSessionManager
    {
        private IUserSessionRepo _userSessionRepo;

        public async Task<UserSession> StartSession(String userName, String category)
        {
            var session = new UserSession();
            session.ID = Guid.NewGuid().ToString();
            session.UserName = userName;
            session.SessionStartTime = DateTime.Now;
            session.Category = category;

            var cleaned = await _userSessionRepo.TerminateSessionsbyUserName(userName);

            var created = false;
            if (cleaned)
            {
                created = await _userSessionRepo.Insert(session);
            }

            if (created)
            {
                return session;
            }
            else
            {
                return null;
            }
        }

        public UserSessionManager(IUserSessionRepo userSessionRepo)
        {
            _userSessionRepo = userSessionRepo;
        }
    }
}
