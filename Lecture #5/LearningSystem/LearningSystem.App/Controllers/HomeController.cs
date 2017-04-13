using System.Web.Mvc;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.App.Controllers
{

    [Authorize(Roles = "Student")]
    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var viewModels = this.service.GetAllCourses();

            return View(viewModels);
        }
    }
}