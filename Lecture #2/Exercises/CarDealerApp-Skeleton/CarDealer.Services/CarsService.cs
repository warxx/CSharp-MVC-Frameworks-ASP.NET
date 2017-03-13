using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class CarsService : Service
    {
        public CarsService(CarDealerContext context) : base(context)
        {
        }

        public IEnumerable<CarsMakeViewModel> GetCarsByMake(string make)
        {
            IEnumerable<Car> cars = this.context.Cars.Where(car => car.Make == make);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarsMakeViewModel>();
            });

            IEnumerable<CarsMakeViewModel> viewModels =
                Mapper.Instance.Map<IEnumerable<Car>, IEnumerable<CarsMakeViewModel>>(cars);

            return viewModels;
        }

        public CarPartsViewModel GetCarPartsVM(int id)
        {
            var car = this.context.Cars.Find(id);
            var parts = car.Parts;

            var viewModel = new CarPartsViewModel()
            {
                Car = car,
                Parts = parts.ToList()
            };

            return viewModel;
        }
    }
}
