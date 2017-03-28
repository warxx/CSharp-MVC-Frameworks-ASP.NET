using System.Linq;
using CameraBazaar.Models.EntityModels;
using static CameraBazaar.Data.Data;

namespace CameraBazaar.App.Security
{
    public class AuthenticationManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            if (Context.Logins
                .Any(x => x.SessionId == sessionId && x.IsActive))
            {
                return true;
            }

            return false;
        }

        public static User GetUser(string sessionId)
        {
            var login = Context.Logins
                .FirstOrDefault(x => x.SessionId == sessionId && x.IsActive);
            return login.User;
        }

        public static void Logout(string sessionId)
        {
            var login = Context.Logins.FirstOrDefault(x => x.SessionId == sessionId);
            login.IsActive = false;
            Context.SaveChanges();
        }
    }
}