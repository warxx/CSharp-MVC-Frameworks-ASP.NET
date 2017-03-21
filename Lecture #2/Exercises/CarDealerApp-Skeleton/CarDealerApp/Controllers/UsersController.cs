using System;
using System.Web;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models.BindingModels;
using CarDealer.Services;
using CarDealerApp.Security;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            this.service = new UsersService(Data.Context);
        }

        [Route("register")]
        [HttpGet]
        public ActionResult Register()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                ViewBag.Username = AuthenticationManager.GetUsername(httpCookie.Value);
                return this.RedirectToAction("Make", "Cars", new { make = "all" } );
            }

            return View();
        }

        [Route("register")]
        [HttpPost]
        public ActionResult Register([Bind(Include = "Username, Email, Password, ConfirmPassword")] RegisterUserBm model)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                ViewBag.Username = AuthenticationManager.GetUsername(httpCookie.Value);
                return this.RedirectToAction("Make", "Cars", new { make = "all" });
            }

            if (this.ModelState.IsValid && model.Password == model.ConfirmPassword)
            {
                this.service.RegisterUserFromBm(model);
                return this.RedirectToAction("Make", "Cars", new { make = "all" });
            }

            return this.View();
        }

        [Route("login")]
        [HttpGet]
        public ActionResult Login()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                //AuthenticationManager.GetUsername(httpCookie.Value);
                return this.RedirectToAction("Make", "Cars", new { make = "all" });
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
                ViewBag.Username = AuthenticationManager.GetUsername(httpCookie.Value);
                return this.RedirectToAction("Make", "Cars", new { make = "all" });
            }

            if (ModelState.IsValid && this.service.IsUserExist(model))
            {
                this.service.LoginUser(this.Session.SessionID, model);
                this.Response.SetCookie(new HttpCookie("sessionId", this.Session.SessionID));
                this.Response.Cookies["sessionId"].Expires = DateTime.Now.AddDays(1);
                return this.RedirectToAction("Make", "Cars", new { make = "all" });
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
            return this.RedirectToAction("Make", "Cars", new {make = "all"});
        }
    }
}