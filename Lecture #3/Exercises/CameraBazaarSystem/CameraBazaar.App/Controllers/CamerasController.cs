using System.Web.Mvc;
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
      //  [Route("~/")]
        [HttpGet]
        public ActionResult All()
        {
            var viewModels = this.service.GetAllCamerasVms();

            return View(viewModels);
        }
    }
}