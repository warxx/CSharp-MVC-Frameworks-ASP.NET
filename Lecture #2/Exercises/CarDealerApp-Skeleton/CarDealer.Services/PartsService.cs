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

        public IEnumerable<AddPartSupplierViewModel> GetSuppliers()
        {
            var suppliers = this.context.Suppliers.ToList();

            var viewModels = Mapper
                .Map<IEnumerable<Supplier>, IEnumerable<AddPartSupplierViewModel>>(suppliers);

            return viewModels;
        }

        public void AddPartFromBm(AddPartBindingModel model)
        {
            Supplier supplier = this.context.Suppliers.Find(model.SupplierId);

            var part = new Part()
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
                Supplier = supplier
            };

            if (part.Quantity <= 0)
            {
                part.Quantity = 1;
            }

            this.context.Parts.Add(part);
            this.context.SaveChanges();
        }

        public void DeletePart(int id)
        {
            var part = this.context.Parts.Find(id);

            this.context.Parts.Remove(part);
            this.context.SaveChanges();
        }

        public EditPartViewModel GetEditPartVm(int id)
        {
            var part = this.context.Parts.Find(id);

            var viewModel = Mapper.Map<Part, EditPartViewModel>(part);
            return viewModel;
        }

        public void EditPartFromBm(EditPartBm model)
        {
            var part = this.context.Parts.Find(model.Id);

            part.Price = model.Price;
            part.Quantity = model.Quantity;

            if (part.Quantity <= 0)
            {
                part.Quantity = 1;
            }

            this.context.SaveChanges();
        }
    }
}
