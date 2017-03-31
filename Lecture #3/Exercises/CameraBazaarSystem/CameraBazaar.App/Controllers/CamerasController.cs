using System.Web.Mvc;
using CameraBazaar.App.Security;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Services;

namespace CameraBazaar.App.Controllers
{
    [RoutePrefix("cameras")]
    public class CamerasController : Controller
    {
        private CamerasService service;

        public CamerasController()
        {
            this.service = new CamerasService(Data.Data.Context);
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

            return this.View();
        }
    }
}