using System.Web.Mvc;
using CarDealer.Data;
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
            var suppliers = this.service.GetSuppliers();

            return this.View(suppliers);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name, Price, SupplierId, Quantity")] AddPartBindingModel model)
        {
            
            if (this.ModelState.IsValid)
            {
                this.service.AddPartFromBm(model);
                return this.RedirectToAction("All", "Parts");
            }

            var suppliers = this.service.GetSuppliers();

            return this.View(suppliers);
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            this.service.DeletePart(id);

            return RedirectToAction("All", "Parts");
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var viewModel = this.service.GetEditPartVm(id);

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id, Price, Quantity")] EditPartBm model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditPartFromBm(model);
                return this.RedirectToAction("All", "Parts");
            }

            return this.View(this.service.GetEditPartVm(model.Id));
        }
    }
}
