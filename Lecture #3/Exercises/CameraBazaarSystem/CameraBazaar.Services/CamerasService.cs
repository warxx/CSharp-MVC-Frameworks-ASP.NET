using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using CameraBazaar.Data;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.EntityModels;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.Services
{
    public class CamerasService : Service
    {

        public IEnumerable<AllCamerasVm> GetAllCamerasVms()
        {
            var cameras = this.data.Context.Cameras;
            var camera = this.data.Context.Cameras.Find(1);

            var viewModels = Mapper.Map<IEnumerable<Camera>, IEnumerable<AllCamerasVm>>(cameras);
            return viewModels;
        }

        public void AddCameraFromBm(AddCameraBm model, User user)
        {
            var camera = Mapper.Map<AddCameraBm, Camera>(model);
            var currentUser = this.data.Context.Users.Find(user.Id);
            currentUser?.Cameras.Add(camera);
            this.data.Context.Cameras.Add(camera);

            this.data.Context.SaveChanges();
        }

        public CameraDetailsVm GetCameraDetailsVm(int? id)
        {
            var camera = this.data.Context.Cameras.FirstOrDefault(x => x.Id == id);

            if (camera == null)
            {
                return null;
            }

            var viewModel = Mapper.Map<Camera, CameraDetailsVm>(camera);
            return viewModel;
        }

        public EditCameraVm GetEditCameraVm(int? id)
        {
            var camera = this.data.Context.Cameras.FirstOrDefault(x => x.Id == id);

            if (camera == null)
            {
                return null;
            }

            var viewModel = Mapper.Map<Camera, EditCameraVm>(camera);

            return viewModel;
        }

        public void EditCameraFromBm(EditCameraBm model)
        {
            var camera = Mapper.Map<EditCameraBm, Camera>(model);
            this.data.Context.Entry(camera).State = EntityState.Modified;
            this.data.Context.SaveChanges();
        }

        public DeleteCameraVm GetDeleteCameraVm(int? id)
        {
            var camera = this.data.Context.Cameras.FirstOrDefault(x => x.Id == id);

            if (camera == null)
            {
                return null;
            }

            var viewModel = Mapper.Map<Camera, DeleteCameraVm>(camera);

            return viewModel;
        }

        public void DeleteCamera(int id)
        {
            var camera = this.data.Context.Cameras.Find(id);
            this.data.Context.Cameras.Remove(camera);
            this.data.Context.SaveChanges();
        }
    }
}
