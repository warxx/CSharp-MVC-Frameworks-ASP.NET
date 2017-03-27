using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models.BindingModels;
using CarDealer.Services;
using CarDealerApp.Security;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("logs")]
    public class LogsController : Controller
    {
        private LogsService service;

        public LogsController()
        {
            this.service = new LogsService(Data.Context);
        }

        [Route("all/{username?}")]
        [HttpGet]
        public ActionResult All(string username)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            var user = AuthenticationManager.GetUser(httpCookie.Value);
            ViewBag.Username = user.Username;

            var viewModels = this.service.GetAllLogsVm(username);
            
            return View(viewModels);
        }
    }
}