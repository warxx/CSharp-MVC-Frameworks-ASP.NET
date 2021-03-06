﻿using System.Linq;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealerApp.Security
{
    public class AuthenticationManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            if (Data.Context.Logins
                .Any(x => x.SessionId == sessionId && x.IsActive))
            { 
                return true;
            }

            return false;
        }

        public static void Logout(string sessionId)
        {
            var login = Data.Context.Logins.FirstOrDefault(x => x.SessionId == sessionId);
            login.IsActive = false;
            Data.Context.SaveChanges();
        }

        public static User GetUser(string sessionId)
        {
            var login = Data.Context.Logins
                .FirstOrDefault(x => x.SessionId == sessionId && x.IsActive);
            return login.User;
        }
    }
}