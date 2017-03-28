using System.Collections.Generic;
using AutoMapper;
using CameraBazaar.Data;
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
    }
}
