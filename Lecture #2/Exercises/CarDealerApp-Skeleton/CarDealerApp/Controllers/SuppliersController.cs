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
    }
}
