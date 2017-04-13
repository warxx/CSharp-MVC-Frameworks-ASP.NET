using System.Web.Mvc;
using LearningSystem.Models.BindingModels.Users;
using LearningSystem.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace LearningSystem.App.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("enroll/{id}")]
        public ActionResult Enroll(int id)
        {
            string userName = this.User.Identity.Name;
            var ids = this.User.Identity.GetUserId();
            var student = this.service.GetCurrentStudent(userName);
            this.service.EnrollStudentInCourse(id, student);
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("profile/")]
        public ActionResult Profile()
        {
            string userName = this.User.Identity.Name;
            var viewModel = this.service.GetProfileVm(userName);

            return this.View(viewModel);
        }

        [HttpGet]
        [Route("edit")]
        public ActionResult Edit()
        {
            string userName = this.User.Identity.Name;
            var viewModel = this.service.GetEditUserVm(userName);

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(EditUserBm model)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserName = this.User.Identity.Name;
                this.service.EditUserFromBm(currentUserName, model);
                return this.RedirectToAction("Profile");
            }

            string userName = this.User.Identity.Name;
            var viewModel = this.service.GetEditUserVm(userName);

            return this.View(viewModel);
        }
    }
}