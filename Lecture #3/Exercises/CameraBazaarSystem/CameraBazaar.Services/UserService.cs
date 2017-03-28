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
    }
}
