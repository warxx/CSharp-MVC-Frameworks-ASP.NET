using System;
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

        public void RegisterUserFromBm(RegisterUserBm model)
        {
            var user = Mapper.Map<RegisterUserBm, User>(model);
            this.data.Context.Users.Add(user);
            this.data.Context.SaveChanges();
        }

        public void LoginUser(string sessionId, LoginUserBm model)
        {
            if (!this.data.Context.Logins.Any(login => login.SessionId == sessionId))
            {
                this.data.Context.Logins.Add(new Login() { SessionId = sessionId });
                this.data.Context.SaveChanges();
            }

            var myLogin = this.data.Context.Logins.FirstOrDefault(x => x.SessionId == sessionId);

            myLogin.IsActive = true;

            var user =
                this.data.Context.Users.FirstOrDefault(
                    x => x.Username == model.Username && x.Password == model.Password);
            myLogin.User = user;
            myLogin.LoginTime = DateTime.Now;

            this.data.Context.SaveChanges();
        }

        public bool IsUserExist(LoginUserBm model)
        {
            return this.data.Context.Users.Any(
                x => x.Username == model.Username && x.Password == model.Password);
        }

        public UserProfileVm GetUserProfileVm(string username)
        {
            var user = this.data.Context.Users.FirstOrDefault(x => x.Username == username);

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

        public UserProfileVm GetMyProfileVm(User user)
        {
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

        public EditProfileVm GetEditProfileVm(User user)
        {
            var vm = new EditProfileVm();
            var currentUser = this.data.Context.Users.Find(user.Id);

            vm.Email = user.Email;
            vm.Phone = user.Phone;

            return vm;
        }

        public void EditProfileFromBm(EditProfileBm model, User user)
        {
            var currentUser = this.data.Context.Users.Find(user.Id);

            currentUser.Email = model.Email;
            currentUser.Phone = model.Phone;
            currentUser.Password = model.NewPassword;

            this.data.Context.SaveChanges();
        }
        
    }
}
