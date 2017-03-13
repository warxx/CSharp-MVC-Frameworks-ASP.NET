using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class CustomersService : Service
    {
        public CustomersService(CarDealerContext context) : base(context)
        {
        }

        public IEnumerable<AllCustomersViewModel> GetAllOrderedCustomers(string order)
        {
            IEnumerable<Customer> customers;
            order = order.ToLower();

            if (order == "ascending")
            {
                customers = this.context.Customers.OrderBy(bd => bd.BirthDate)
                     .ThenBy(yd => yd.IsYoungDriver).ToList();
            }
            else if (order == "descending")
            {
                customers = this.context.Customers.OrderByDescending(bd => bd.BirthDate)
                    .ThenBy(yd => yd.IsYoungDriver).ToList();
            }
            else
            {
                throw new ArgumentException("The argument you have given for the order is invalid!");
            }


            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, AllCustomersViewModel>();
            });
            IEnumerable<AllCustomersViewModel> viewModels =
                Mapper.Instance.Map<IEnumerable<Customer>, IEnumerable<AllCustomersViewModel>>(customers);

            return viewModels;
        }

        public CustomerViewModel GetCustomerById(int id)
        {
            var customer = this.context.Customers.Find(id);
            double? moneySpent = customer.Sales.Sum(sale=>sale.Car.Parts.Sum(part=>part.Price));

            var viewModel = new CustomerViewModel()
            {
                Customer = customer,
                TotalSpentMoney = moneySpent
            };

            return viewModel;
        }
    }
}
