using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.BindingModels;

namespace CarDealer.Services
{
    public class UsersService : Service
    {
        public UsersService(CarDealerContext context) : base(context)
        {
        }

        public void RegisterUserFromBm(RegisterUserBm model)
        {
            var user = Mapper.Map<RegisterUserBm, User>(model);
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public bool IsUserExist(LoginUserBm model)
        {
            return this.context.Users
                .Any(x => x.Username == model.Username && x.Password == model.Password);
        }

        public void LoginUser(string sessionId, LoginUserBm model)
        {
            if (!this.context.Logins.Any(login => login.SessionId == sessionId))
            {
                this.context.Logins.Add(new Login() {SessionId = sessionId});
                this.context.SaveChanges();
            }

            var myLogin = this.context.Logins.FirstOrDefault(x => x.SessionId == sessionId);

            myLogin.IsActive = true;

            var user =
                this.context.Users.FirstOrDefault(
                    x => x.Username == model.Username && x.Password == model.Password);
            myLogin.User = user;

            this.context.SaveChanges();
        }
    }
}
