using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
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
    }
}
