using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CarDealer.Models;
using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;

namespace CarDealerApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, AllCustomersViewModel>();
                cfg.CreateMap<Car, CarsMakeViewModel>();
                cfg.CreateMap<Sale, SaleViewModel>()
                    .ForMember(vm => vm.Model,
                        cfgExpression => cfgExpression
                            .MapFrom(sale => sale.Car.Model))
                    .ForMember(vm => vm.Make,
                        cfgExpression => cfgExpression
                            .MapFrom(sale => sale.Car.Make))
                    .ForMember(vm => vm.TravelledDistance,
                        cfgExpression => cfgExpression
                            .MapFrom(sale => sale.Car.TravelledDistance))
                    .ForMember(vm => vm.CustomerName,
                        cfgExpression => cfgExpression
                            .MapFrom(sale => sale.Customer.Name))
                    .ForMember(vm => vm.PriceWithDiscount,
                        cfgExpression => cfgExpression
                            .MapFrom(sale => sale.Car.Parts.Sum(x => x.Price)*(1 + sale.Discount)))
                    .ForMember(vm => vm.PriceWithoutDiscount,
                        cfgExpression => cfgExpression
                            .MapFrom(sale => sale.Car.Parts.Sum(x => x.Price)));
                cfg.CreateMap<Supplier, FilterSuppliersViewModel>()
                    .ForMember(vm => vm.PartsCount,
                        cfgExpression => cfgExpression
                            .MapFrom(supplier => supplier.Parts.Count));
                cfg.CreateMap<AddCustomerBm, Customer>();
                cfg.CreateMap<Customer, EditCustomerViewModel>();
                cfg.CreateMap<EditCustomerBm, Customer>();
                cfg.CreateMap<Part, PartViewModel>()
                    .ForMember(vm => vm.SupplierName,
                        cfgExpression => cfgExpression
                            .MapFrom(name => name.Supplier.Name));
            });
        }
    }
}
