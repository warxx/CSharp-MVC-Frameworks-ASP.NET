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

        public void AddCustomerBm(AddCustomerBm model)
        {
            var customer = Mapper.Instance.Map<AddCustomerBm, Customer>(model);
            customer.IsYoungDriver = false;


            if (DateTime.Now.Year - model.BirthDate.Year < 21)
                customer.IsYoungDriver = true;

            this.context.Customers.Add(customer);
            this.context.SaveChanges();
        }

        public EditCustomerViewModel GetEditCustomerVm(int id)
        {
            var customer = this.context.Customers.Find(id);

            if (customer == null)
            {
                throw new ArgumentException("Cannot find customer with such id!");
            }

            return Mapper.Map<Customer, EditCustomerViewModel>(customer);
        }

        public void EditCustomer(EditCustomerBm model)
        {
            var customer = this.context.Customers.Find(model.Id);

            if (customer == null)
            {
                throw new ArgumentException("Cannot find customer with such id!");
            }

            customer.Name = model.Name;
            customer.BirthDate = model.BirthDate;
            this.context.SaveChanges();
        }
    }
}
