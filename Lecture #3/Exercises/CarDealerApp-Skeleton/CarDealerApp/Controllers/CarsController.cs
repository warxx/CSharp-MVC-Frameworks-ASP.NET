using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;
using CarDealer.Services;
using CarDealerApp.Security;

namespace CarDealerApp.Controllers
{
    public class CarsController : Controller
    {
        private CarsService service;

        public CarsController()
        {
            this.service = new CarsService(Data.Context);
        }

        [HttpGet]
        public ActionResult Make(string make)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                var user = AuthenticationManager.GetUser(httpCookie.Value);
                ViewBag.Username = user.Username;
            }

                IEnumerable<CarsMakeViewModel> cars =
                this.service.GetCarsByMake(make);

            return View(cars);
        }


        //public ActionResult All()
        //{
        //    return View(db.Cars.ToList());
        //}

        public ActionResult Parts(int id)
        {
            var viewModel = this.service.GetCarPartsVM(id);

            return View(viewModel);
        }

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

            var partsVm = this.service.GetAddCarPartsVm();

            return this.View(partsVm);
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "Make, CarModel, TravelledDistance, PartsId")] AddCarBindingModel carBm)
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
                this.service.AddCarFromBm(carBm, user.Id);
                return this.RedirectToAction("Make", "Cars", new {make = "all"});
            }

            return this.View(this.service.GetAddCarPartsVm());
        }
    }
}