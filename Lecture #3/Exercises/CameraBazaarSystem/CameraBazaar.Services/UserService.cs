using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CameraBazaar.Data;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.EntityModels;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.Services
{
    public class UserService : Service
    {
        public UserService(CameraBazaarContext context) : base(context)
        {
        }

        public void RegisterUserFromBm(RegisterUserBm model)
        {
            var user = Mapper.Map<RegisterUserBm, User>(model);
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void LoginUser(string sessionId, LoginUserBm model)
        {
            if (!this.context.Logins.Any(login => login.SessionId == sessionId))
            {
                this.context.Logins.Add(new Login() { SessionId = sessionId });
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

        public bool IsUserExist(LoginUserBm model)
        {
            return this.context.Users.Any(
                x => x.Username == model.Username && x.Password == model.Password);
        }

        public UserProfileVm GetUserProfileVm(string username)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                return null;
            }

            var viewModel = new UserProfileVm();
            viewModel.Id = user.Id;
            viewModel.Username = user.Username;
            viewModel.Phone = user.Phone;
            viewModel.Email = user.Email;
            viewModel.InStockCameras = user.Cameras.Count(x => x.Quantity > 0);
            viewModel.OutStockCameras = user.Cameras.Count(x => x.Quantity == 0);
            viewModel.UserCameras = Mapper.Map<IEnumerable<Camera>, IEnumerable<AllCamerasVm>>(user.Cameras);

            return viewModel;
        }
        
    }
}
