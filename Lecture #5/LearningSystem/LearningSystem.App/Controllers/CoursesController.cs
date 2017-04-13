using System.Web.Mvc;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.App.Controllers
{
    [Authorize(Roles = "Student")]
    [RoutePrefix("courses")]
    public class CoursesController : Controller
    {
        private ICoursesService service;

        public CoursesController(ICoursesService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            var viewModel = this.service.GetCourseDetailsVm(id);
            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            return View(viewModel);
        }
    }
}