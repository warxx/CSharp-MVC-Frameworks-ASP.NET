using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{

    public class CustomersController : Controller
    {

        private CustomersService service;

        public CustomersController()
        {
            this.service = new CustomersService(Data.Context);
        }

        [HttpGet]
        public ActionResult All(string order)
        {
            var customers = this.service.GetAllOrderedCustomers(order);

            return View(customers);
        }

        public ActionResult Customer(int id)
        {
            var viewModel = this.service.GetCustomerById(id);

            return View(viewModel);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        Data.Context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
