using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Ordered Customers",
                url: "customers/all/{order}",
                defaults: new
                {
                    controller = "Customers",
                    action = "All",
                    order = "Ascending"
                },
                constraints: new
                {
                    order = @"ascending|descending"
                }
            );

            routes.MapRoute(
                name: "Cars",
                url: "cars/{make}",
                defaults: new
                {
                    controller = "Cars",
                    action = "Make"
                }
                );

            routes.MapRoute(
                name: "Suppliers",
                url: "suppliers/{type}",
                defaults: new
                {
                    controller = "Suppliers",
                    action = "All",
                    type = "Local"
                }
            );

            routes.MapRoute(
                name: "Parts",
                url: "cars/{id}/parts",
                defaults: new
                {
                    controller = "Cars",
                    action = "Parts"
                },
                constraints: new
                {
                    id = @"\d+"
                }
            );

            routes.MapRoute(
                name: "Customer",
                url: "customers/{id}",
                defaults: new
                {
                    controller = "Customers",
                    action = "Customer"
                },
                constraints: new
                {
                    id = @"\d+"
                }
            );

            routes.MapRoute(
                name: "All Sales",
                url: "sales",
                defaults: new
                {
                    controller = "Sales",
                    action = "All"
                }
            );

            routes.MapRoute(
                name: "Sale Details",
                url: "sales/{id}",
                defaults: new
                {
                    controller = "Sales",
                    action = "Sale"
                },
                constraints: new
                {
                    id = @"\d+"
                }
            );

            routes.MapRoute(
                name: "Discounted Sales",
                url: "sales/discounted",
                defaults: new
                {
                    controller = "Sales",
                    action = "Discounted"
                }
            );

            routes.MapRoute(
                name: "Discounted Sales by percent",
                url: "sales/discounted/{percent}/",
                defaults: new
                {
                    controller = "Sales",
                    action = "Percent"
                }
            );

            routes.MapRoute(
                name: "Add Customers",
                url: "customers/add",
                defaults: new
                {
                    controller = "Customers",
                    action = "Add"
                }
            );

            routes.MapRoute(
                name: "Edit Customers",
                url: "customers/edit/{id}",
                defaults: new
                {
                    controller = "Customers",
                    action = "Edit"
                },
                constraints: new
                {
                    id = @"\d+"
                }
            );
        }
    }
}
