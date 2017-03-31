using System;
using System.Web;
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
                return this.RedirectToAction("Login", "Users");
            }

            return View();
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                var user = AuthenticationManager.GetUser(httpCookie.Value);
                ViewBag.Username = user.Username;

                return this.RedirectToAction("All", "Cameras");
            }

            return this.View();
        }

        [Route("login")]
        [HttpPost]
        public ActionResult Login([Bind(Include = "Username, Password")] LoginUserBm model)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                var user = AuthenticationManager.GetUser(httpCookie.Value);
                ViewBag.Username = user.Username;

                return this.RedirectToAction("All", "Cameras");
            }

            if (ModelState.IsValid && this.service.IsUserExist(model))
            {
                this.service.LoginUser(this.Session.SessionID, model);
                this.Response.SetCookie(new HttpCookie("sessionId", this.Session.SessionID));
                this.Response.Cookies["sessionId"].Expires = DateTime.Now.AddDays(1);
                return this.RedirectToAction("All", "Cameras");
            }

            return this.View();
        }

        [HttpGet]
        [Route("logout")]
        public ActionResult Logout()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login");
            }

            AuthenticationManager.Logout(httpCookie.Value);
            return this.RedirectToAction("All", "Cameras");
        }

        [Route("profile/{username?}")]
        [HttpGet]
        public ActionResult Profile(string username)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login");
            }

            var user = AuthenticationManager.GetUser(httpCookie.Value);
            ViewBag.Username = user.Username;

            var viewModel = this.service.GetUserProfileVm(username);

            if (viewModel == null)
            {
                return new HttpNotFoundResult("Current profile is not found. :(");
            }

            return this.View(viewModel);
        }
    }
}