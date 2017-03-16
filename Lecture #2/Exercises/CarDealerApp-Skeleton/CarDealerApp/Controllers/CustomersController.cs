using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.BindingModels;
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

        [HttpGet]
        public ActionResult Customer(int id)
        {
            var viewModel = this.service.GetCustomerById(id);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        public ActionResult Add([Bind(Include = "Name, BirthDate")] AddCustomerBm model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddCustomerBm(model);
                return this.RedirectToAction("All", new {order = "ascending"});
            }

            return this.View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = this.service.GetEditCustomerVm(id);

            return this.View(viewModel);
        }
    }
}
