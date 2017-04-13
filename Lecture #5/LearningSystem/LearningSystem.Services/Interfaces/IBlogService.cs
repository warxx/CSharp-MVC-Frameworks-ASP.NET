using System.Collections.Generic;
using LearningSystem.Models.BindingModels.Blog;
using LearningSystem.Models.ViewModels.Blog;

namespace LearningSystem.Services.Interfaces
{
    public interface IBlogService
    {
        IEnumerable<ArticleVm> GetAllArticlesVm();
        void AddArticleFromBm(AddArticleBm model, string userName);
    }
}