using System;
using System.Linq;
using CameraBazaar.Data;
using CameraBazaar.Models.EntityModels;
using Microsoft.Ajax.Utilities;

namespace CameraBazaar.App.Security
{
    public class AuthenticationManager
    {

        public static bool IsAuthenticated(string sessionId)
        {
            var data = new Data.Data();

            return data.Context.Logins
                .Any(x => x.SessionId == sessionId && x.IsActive);
        }

        public static User GetUser(string sessionId)
        {
            var data = new Data.Data();

            var login = data.Context.Logins
                .FirstOrDefault(x => x.SessionId == sessionId && x.IsActive);
            return login.User;
        }

        public static void Logout(string sessionId)
        {
            var data = new Data.Data();

            var login = data.Context.Logins.FirstOrDefault(x => x.SessionId == sessionId);
            login.IsActive = false;
            login.User.LastLoginTime = login.LoginTime;
            data.Context.SaveChanges();
        }
    }
}