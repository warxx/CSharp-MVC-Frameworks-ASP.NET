using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.EntityModels;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Camera, AllCamerasVm>()
                    .ForMember(vm => vm.Make,
                        cfgExpression => cfgExpression
                            .MapFrom(camera => camera.Make));
                cfg.CreateMap<User, RegisterUserVm>();
                cfg.CreateMap<RegisterUserBm, User>();
                cfg.CreateMap<Camera, AddCameraVm>();
                cfg.CreateMap<AddCameraBm, Camera>();
            });
            
        }
    }
}
