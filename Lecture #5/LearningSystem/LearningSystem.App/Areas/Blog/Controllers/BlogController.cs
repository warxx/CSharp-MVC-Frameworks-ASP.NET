using System.Web.Mvc;
using System.Web.UI.WebControls;
using LearningSystem.Models.BindingModels.Blog;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.App.Areas.Blog.Controllers
{
    [RouteArea("blog")]
    [Authorize(Roles = "Student")]
    public class BlogController : Controller
    {
        private IBlogService service;

        public BlogController(IBlogService service)
        {
            this.service = service;
        }

        [Route("All")]
        [HttpGet]
        public ActionResult All()
        {
            var viewModels = this.service.GetAllArticlesVm();

            return this.View(viewModels);
        }

        [Route("add")]
        [HttpGet]
        [Authorize(Roles = "BlogAuthor")]
        public ActionResult Add()
        {
            return this.View();
        }

        [Route("add")]
        [HttpPost]
        [Authorize(Roles = "BlogAuthor")]
        public ActionResult Add(AddArticleBm model)
        {
            if (this.ModelState.IsValid)
            {
                string userName = this.User.Identity.Name;
                this.service.AddArticleFromBm(model, userName);

                return RedirectToAction("All");
            }

            return this.View();
        }
    }
}