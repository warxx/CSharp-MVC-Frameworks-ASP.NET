using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.ViewModels;
using CarDealer.Services;
using AuthenticationManager = CarDealerApp.Security.AuthenticationManager;

namespace CarDealerApp.Controllers
{

    public class SuppliersController : Controller
    {
        private SupliersService service;

        public SuppliersController()
        {
            this.service = new SupliersService(Data.Context);
        }

        public ActionResult All(string type)
        {
            IEnumerable<FilterSuppliersViewModel> viewModels =
                this.service.GetAllSuppliers(type);

            return View(viewModels);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            ViewBag.Username = AuthenticationManager.GetUsername(httpCookie.Value);

            return this.View();
        }

        public ActionResult Add(bind)
    }
}
