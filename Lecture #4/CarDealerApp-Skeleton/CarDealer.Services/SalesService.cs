
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class SalesService : Service
    {
        public SalesService(CarDealerContext context) : base(context)
        {
        }

        public IEnumerable<SaleViewModel> GetAllSales()
        {
            IEnumerable<Sale> sales = this.context.Sales;

            IEnumerable<SaleViewModel> viewModels =
                Mapper.Instance.Map<IEnumerable<Sale>, IEnumerable<SaleViewModel>>(sales);

            return viewModels;
        }

        public SaleViewModel GetSaleViewModel(int id)
        {
            var sale = this.context.Sales.Find(id);

            SaleViewModel viewModel = new SaleViewModel()
            {
                Id = sale.Id,
                CustomerName = sale.Customer.Name,
                Discount = sale.Discount,
                Make = sale.Car.Make,
                Model = sale.Car.Model,
                PriceWithDiscount = sale.Car.Parts.Sum(x => x.Price*(1 + sale.Discount)),
                PriceWithoutDiscount = sale.Car.Parts.Sum(x => x.Price),
                TravelledDistance = sale.Car.TravelledDistance
            };

            return viewModel;
        }

        public IEnumerable<SaleViewModel> GetAllDiscountedSales()
        {
            IEnumerable<Sale> sales = this.context.Sales.Where(x=>x.Discount > 0);

            IEnumerable<SaleViewModel> viewModels =
                Mapper.Instance.Map<IEnumerable<Sale>, IEnumerable<SaleViewModel>>(sales);

            return viewModels;
        }

        public IEnumerable<SaleViewModel> GetAllSalesWithGivenPercent(double? percent)
        {
            IEnumerable<Sale> sales = this.context.Sales.Where(p=>p.Discount == percent);

            IEnumerable<SaleViewModel> viewModels =
                Mapper.Instance.Map<IEnumerable<Sale>, IEnumerable<SaleViewModel>>(sales);

            return viewModels;
        }

        public AddSaleVm GetAddSaleVm()
        {
            var viewModel = new AddSaleVm();

            var customers = this.context.Customers.ToList();

            var cars = this.context.Cars.ToList();

            List<int> discounts = new List<int>();
            for (int i = 0; i < 50; i+=5)
            {
                discounts.Add(i);
            }

            viewModel.Customers = customers;
            viewModel.Cars = cars;
            viewModel.Discounts = discounts;

            return viewModel;
        }

        public SaleReviewVm GetSaleReviewVm(AddSaleBm model)
        {
            var viewModel = new SaleReviewVm();
            var car = this.context.Cars.Find(model.CarId);
            var customer = this.context.Customers.Find(model.CustomerId);


            viewModel.CarId = car.Id;
            viewModel.CustomerId = customer.Id;
            viewModel.CustomerName = customer.Name;
            viewModel.CarName = car.Make + " " + car.Model;
            viewModel.CarPrice = car.Parts.Sum(x => x.Price);
            viewModel.IsYoungDriver = customer.IsYoungDriver;
            viewModel.Discount = model.Discount;

            viewModel.Discount += customer.IsYoungDriver ? 5 : 0;
            viewModel.FinalCarPrice = viewModel.CarPrice / (1 + (viewModel.Discount / 100));
            return viewModel;
        }

        public void AddSaleFromBm(SaleReviewBm model, int userId)
        {
            var sale = new Sale()
            {
                Car = this.context.Cars.Find(model.CarId),
                Customer = this.context.Customers.Find(model.CustomerId),
                Discount = model.Discount/100
            };

            this.context.Sales.Add(sale);

            var user = this.context.Users.Find(userId);
            var log = new Log()
            {
                User = user,
                ModifiedTable = "Sale",
                Operation = OperationLog.Add,
                ModifyingDate = DateTime.Now
            };

            this.context.Logs.Add(log);

            this.context.SaveChanges();
        }
    }
}
