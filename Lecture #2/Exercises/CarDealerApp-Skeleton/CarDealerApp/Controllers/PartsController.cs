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
using CarDealer.Models.BindingModels;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("parts")]
    public class PartsController : Controller
    {
        private PartsService service;

        public PartsController()
        {
            this.service = new PartsService(Data.Context);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            var parts = this.service.GetAllParts();

            return View(parts);
        }



        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }

        public ActionResult Add(AddPartBindingModel model)
        {
            this.service.AddPartFromBm(model);
        }
    }
}
