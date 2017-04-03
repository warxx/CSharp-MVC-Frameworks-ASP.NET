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
    public class CarsService : Service
    {
        public CarsService(CarDealerContext context) : base(context)
        {
        }

        public IEnumerable<CarsMakeViewModel> GetCarsByMake(string make)
        {
            make = make.ToLower();
            IEnumerable<Car> cars;

            if (make == "all" || string.IsNullOrEmpty(make))
            {
                cars = this.context.Cars.ToList();
            }
            else
            {
                cars = this.context.Cars.Where(car => car.Make == make);
            }

            IEnumerable<CarsMakeViewModel> viewModels =
                Mapper.Instance.Map<IEnumerable<Car>, IEnumerable<CarsMakeViewModel>>(cars);

            return viewModels;
        }

        public CarPartsViewModel GetCarPartsVM(Car car)
        {
            var parts = car.Parts;



            var viewModel = new CarPartsViewModel()
            {
                Car = car,
                Parts = parts.ToList()
            };

            return viewModel;
        }

        public IEnumerable<AddCarPartVm> GetAddCarPartsVm()
        {
            IEnumerable<Part> parts = this.context.Parts.ToList();
            var partsVm = Mapper.Map<IEnumerable<Part>, IEnumerable<AddCarPartVm>>(parts);

            return partsVm;
        }

        public void AddCarFromBm(AddCarBindingModel model, int userId)
        {
            var car = new Car()
            {
                Make = model.Make,
                Model = model.CarModel,
                TravelledDistance = model.TravelledDistance
            };

            foreach (var partId in model.PartsId)
            {
                var part = this.context.Parts.Find(partId);
                car.Parts.Add(part);
            }

            this.context.Cars.Add(car);


            var user = this.context.Users.Find(userId);
            var log = new Log()
            {
                User = user,
                ModifiedTable = "Car",
                Operation = OperationLog.Add,
                ModifyingDate = DateTime.Now
            };

            this.context.Logs.Add(log);
            this.context.SaveChanges();
        }
    }
}
