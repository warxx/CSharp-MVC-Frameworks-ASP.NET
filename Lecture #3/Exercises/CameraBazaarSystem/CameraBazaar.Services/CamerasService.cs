using System.Collections.Generic;
using AutoMapper;
using CameraBazaar.Data;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.EntityModels;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.Services
{
    public class CamerasService : Service
    {
        public CamerasService(CameraBazaarContext context) : base(context)
        {
        }

        public IEnumerable<AllCamerasVm> GetAllCamerasVms()
        {
            var cameras = this.context.Cameras;

            var viewModels = Mapper.Map<IEnumerable<Camera>, IEnumerable<AllCamerasVm>>(cameras);
            return viewModels;
        }

        public void AddCameraFromBm(AddCameraBm model, User user)
        {
            var camera = Mapper.Map<AddCameraBm, Camera>(model);
            var currentUser = this.context.Users.Find(user.Id);
            currentUser?.Cameras.Add(camera);
            this.context.Cameras.Add(camera);

            this.context.SaveChanges();
        }


        
    }
}
