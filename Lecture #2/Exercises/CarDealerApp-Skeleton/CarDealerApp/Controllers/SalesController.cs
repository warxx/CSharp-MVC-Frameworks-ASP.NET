using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{
    public class SalesController : Controller
    {
        private SalesService service;

        public SalesController()
        {
            this.service = new SalesService(Data.Context);
        }

        public ActionResult All()
        {
            var viewModels = this.service.GetAllSales();

            return this.View(viewModels);
        }

        public ActionResult Sale(int id)
        {
            var viewModel = this.service.GetSaleViewModel(id);

            return this.View(viewModel);
        }

        public ActionResult Discounted()
        {
            var viewModels = this.service.GetAllDiscountedSales();

            return this.View(viewModels);
        }

        public ActionResult Percent(double? percent)
        {
            var viewModels = this.service.GetAllSalesWithGivenPercent(percent);

            return this.View(viewModels);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
