using System.Net;
using System.Web.Mvc;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.ViewModels;
using CameraBazaar.Services;
using AuthenticationManager = CameraBazaar.App.Security.AuthenticationManager;

namespace CameraBazaar.App.Controllers
{
    [RoutePrefix("cameras")]
    public class CamerasController : Controller
    {
        private CamerasService service;

        public CamerasController()
        {
            this.service = new CamerasService();
        }

        [Route("all")]
        [Route("~/")]
        [HttpGet]
        public ActionResult All()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                var user = AuthenticationManager.GetUser(httpCookie.Value);
                ViewBag.Username = user.Username;
            }

            var viewModels = this.service.GetAllCamerasVms();

            return View(viewModels);
        }

        [Route("add")]
        [HttpGet]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            var user = AuthenticationManager.GetUser(httpCookie.Value);
            ViewBag.Username = user.Username;

            return this.View();
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Add([Bind(Exclude = "")] AddCameraBm model)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            var user = AuthenticationManager.GetUser(httpCookie.Value);
            ViewBag.Username = user.Username;

            if (this.ModelState.IsValid)
            {
                this.service.AddCameraFromBm(model, user);
                return this.RedirectToAction("All", "Cameras");
            }

            var viewModel = Mapper.Map<AddCameraBm, AddCameraVm>(model);
            return this.View(viewModel);
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null)
            {
                var user = AuthenticationManager.GetUser(httpCookie.Value);
                ViewBag.Username = user.Username;
            }

            var viewModel = this.service.GetCameraDetailsVm(id);

            if (viewModel == null)
            {
                return new HttpNotFoundResult("NO CAMERA WITH THIS ID!!!");
            }

            return this.View(viewModel);
        }

        [Route("edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = AuthenticationManager.GetUser(httpCookie.Value);
            ViewBag.Username = user.Username;

            var viewModel = this.service.GetEditCameraVm(id);

            if (viewModel == null)
            {
                return new HttpNotFoundResult("NO CAMERA WITH THIS ID!!!");
            }

            return this.View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "")] EditCameraBm model)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            var user = AuthenticationManager.GetUser(httpCookie.Value);
            ViewBag.Username = user.Username;

            if (this.ModelState.IsValid)
            {
                this.service.EditCameraFromBm(model);
                return this.RedirectToAction("Profile", "Users");
            }

            var viewModel = this.service.GetEditCameraVm(model.Id);

            return this.View(viewModel);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = AuthenticationManager.GetUser(httpCookie.Value);
            ViewBag.Username = user.Username;

            var viewModel = this.service.GetDeleteCameraVm(id);

            if (viewModel == null)
            {
                return new HttpNotFoundResult("NO CAMERA WITH THIS ID!!!");
            }

            return this.View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            this.service.DeleteCamera(id);

            return this.RedirectToAction("Profile", "Users");
        }
    }
}