using System.Web.Mvc;
using LearningSystem.App.Attributes;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.App.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "Admin")]
    [RouteArea("admin")]
    public class AdminController : Controller
    {
        private IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            var viewModels = this.service.GetIndexPageVm();

            return this.View(viewModels);
        }

        [HttpGet]
        [Route("courses/add")]
        public ActionResult Add()
        {
          //  var viewModel = this.service.AddCourseVm();

            return this.View();
        }
    }
}