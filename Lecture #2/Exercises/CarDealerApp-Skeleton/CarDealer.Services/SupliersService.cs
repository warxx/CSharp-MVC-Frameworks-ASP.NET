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
    public class SupliersService : Service
    {
        public SupliersService(CarDealerContext context) : base(context)
        {
        }

        public IEnumerable<FilterSuppliersViewModel> GetAllSuppliers(string type)
        {
            IEnumerable<Supplier> suppliers;

            type = type.ToLower();

            if (type == "local")
            {
                suppliers = this.context.Suppliers.Where(x => !x.IsImporter);
            }
            else if (type == "importers")
            {
                suppliers = this.context.Suppliers.Where(x => x.IsImporter);
            }
            else
            {
                throw new ArgumentException("The argument you have given for the order is invalid!");
            }

            IEnumerable<FilterSuppliersViewModel> viewModels =
                Mapper.Instance.Map<IEnumerable<Supplier>, IEnumerable<FilterSuppliersViewModel>>(suppliers);

            return viewModels;
        }

        public void AddSupplierFromBm(AddSupplierBm model)
        {
            var supplier = Mapper.Map<AddSupplierBm, Supplier>(model);

            this.context.Suppliers.Add(supplier);
            this.context.SaveChanges();
        }

        public EditSupplierVm GetEditSupplierVm(int id)
        {
            var supplier = this.context.Suppliers.Find(id);

            var viewModel = new EditSupplierVm()
            {
                Id = id,
                Name = supplier.Name
            };

            return viewModel;
        }

        public void EditSupplier(EditSupplierBm model)
        {
            var supplier = this.context.Suppliers.Find(model.Id);

            supplier.Name = model.Name;
            this.context.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            var parts = this.context.Parts.Where(x => x.Supplier.Id == id);
            var supplier = this.context.Suppliers.Find(id);
            this.context.Parts.RemoveRange(parts);
            this.context.Suppliers.Remove(supplier);
            this.context.SaveChanges();
        }
    }
}
