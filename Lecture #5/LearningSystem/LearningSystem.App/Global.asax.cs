using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using LearningSystem.Models.BindingModels.Blog;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Models.ViewModels.Users;

namespace LearningSystem.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Course, CourseVm>();
                cfg.CreateMap<Course, DetailsCourseVm>();
                cfg.CreateMap<ApplicationUser, UserProfileVm>();
                cfg.CreateMap<Course, UserCourseVm>();
                cfg.CreateMap<ApplicationUser, EditUsersVm>();
                cfg.CreateMap<Article, ArticleVm>();
                cfg.CreateMap<ApplicationUser, ArticleAuthorVm>();
                cfg.CreateMap<AddArticleBm, Article>();
                cfg.CreateMap<Student, StudentVm>()
                    .ForMember(vm => vm.Name, cfgExpression =>
                            cfgExpression.MapFrom(student => student.User.Name));
            });
        }
    }
}
