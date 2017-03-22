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
using CarDealer.Models.BindingModels;
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

        [HttpPost]
        public ActionResult Add([Bind(Include = "Name, IsImporter")] AddSupplierBm model)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            ViewBag.Username = AuthenticationManager.GetUsername(httpCookie.Value);

            if (this.ModelState.IsValid)
            {
                this.service.AddSupplierFromBm(model);
                return this.RedirectToAction("All", "Suppliers");
            }

            return this.View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            ViewBag.Username = AuthenticationManager.GetUsername(httpCookie.Value);

            var viewModel = this.service.GetEditSupplierVm(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Name")] EditSupplierBm model)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            ViewBag.Username = AuthenticationManager.GetUsername(httpCookie.Value);

            if (this.ModelState.IsValid)
            {
                this.service.EditSupplier(model);
                return this.RedirectToAction("All", "Suppliers");
            }

            var vm = this.service.GetEditSupplierVm(model.Id);

            return this.View(vm);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.service.DeleteSupplier(id);

            return this.RedirectToAction("All", "Suppliers");
        }
    }
}
