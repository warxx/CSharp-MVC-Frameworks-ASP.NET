using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealer.Data;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        private CarDealerContext context = new CarDealerContext();

        [Route("index")]
        [HttpGet]
        public ActionResult Index()
        {
            throw new Exception("Test exception message");

           // return View();
        }

        public ActionResult About()
        {
            var ctx = new CarDealer.Data.CarDealerContext();
            ViewBag.Message = "Your application description page." + ctx.Cars.Count();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}