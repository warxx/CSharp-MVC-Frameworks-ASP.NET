using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LearningSystem.Models.BindingModels.Blog;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
    public class BlogService : Service, IBlogService
    {
        public IEnumerable<ArticleVm> GetAllArticlesVm()
        {
            var articles = this.Context.Articles.ToList();
            var viewModels = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);
            return viewModels;
        }

        public void AddArticleFromBm(AddArticleBm model, string userName)
        {
            var currentUser = this.Context.Users.FirstOrDefault(x => x.UserName == userName);

            var article = Mapper.Map<AddArticleBm, Article>(model);
            article.Author = currentUser;
            article.PublishDate = DateTime.Now;
            this.Context.Articles.Add(article);

            this.Context.SaveChanges();
        }
    }
}
