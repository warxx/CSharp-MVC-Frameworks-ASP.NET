
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
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
    }
}
