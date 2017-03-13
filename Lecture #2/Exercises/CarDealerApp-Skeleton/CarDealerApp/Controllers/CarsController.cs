using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.ViewModels;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{

    public class CarsController : Controller
    {
        private CarsService service;

        public CarsController()
        {
            this.service = new CarsService(Data.Context);
        }

        public ActionResult Make(string make)
        {
            IEnumerable<CarsMakeViewModel> cars =
                this.service.GetCarsByMake(make);

            return View(cars);
        }


        //public ActionResult All()
        //{
        //    return View(db.Cars.ToList());
        //}

        public ActionResult Parts(int id)
        {
            var viewModel = this.service.GetCarPartsVM(id);

            return View(viewModel);
        }
    }
}
