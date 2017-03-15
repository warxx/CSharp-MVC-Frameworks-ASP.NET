using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class PartsService : Service
    {
        public PartsService(CarDealerContext context) : base(context)
        {
        }

        public IEnumerable<PartViewModel> GetAllParts()
        {
            var parts = this.context.Parts.ToList();

            var viewModels = Mapper.Instance
                .Map<IEnumerable<Part>, IEnumerable<PartViewModel>>(parts);

            return viewModels;
        }

        public void AddPartFromBm(AddPartBindingModel model)
        {
            Supplier supplier = this.context.Suppliers.Find();

            var part = new Part()
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
                Supplier = supplier
            }
        }
    }
}
