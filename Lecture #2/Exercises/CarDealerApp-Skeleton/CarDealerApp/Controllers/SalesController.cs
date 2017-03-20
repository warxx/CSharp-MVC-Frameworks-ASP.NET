using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;
using CarDealer.Services;
using AuthenticationManager = CarDealerApp.Security.AuthenticationManager;

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

        [HttpGet]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            ViewBag.Username = AuthenticationManager.GetUsername(httpCookie.Value);

            var viewModel = this.service.GetAddSaleVm();

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "CustomerId, CarId, Discount")] AddSaleBm model)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            ViewBag.Username = AuthenticationManager.GetUsername(httpCookie.Value);

            if (this.ModelState.IsValid)
            {
                var saleReviewVm = this.service.GetSaleReviewVm(model);
                return this.RedirectToAction("Review", saleReviewVm);
            }

            var viewModel = this.service.GetAddSaleVm();

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Review(SaleReviewVm vm)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            return this.View(vm);
        }
    }
}
