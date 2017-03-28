using System.Web.Mvc;
using CameraBazaar.App.Security;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.ViewModels;
using CameraBazaar.Services;

namespace CameraBazaar.App.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private UserService service;
      
        public UsersController()
        {
            this.service = new UserService(Data.Data.Context);
        }

        [Route("register")]
        [HttpGet]
        public ActionResult Register()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                var user = AuthenticationManager.GetUser(httpCookie.Value);
                ViewBag.Username = user.Username;

                return this.RedirectToAction("All", "Cameras");
            }

            var model = new RegisterUserVm();

            return View(model);
        }

        [Route("register")]
        [HttpPost]
        public ActionResult Register([Bind(Include =
            "Username, Email, Password, ConfirmPassword, Phone")] RegisterUserBm model)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                var user = AuthenticationManager.GetUser(httpCookie.Value);
                ViewBag.Username = user.Username;

                return this.RedirectToAction("All", "Cameras");
            }

            if (this.ModelState.IsValid)
            {
                this.service.RegisterUserFromBm(model);
                return this.RedirectToAction("All", "Cameras");
            }

            return View();
        }
    }
}