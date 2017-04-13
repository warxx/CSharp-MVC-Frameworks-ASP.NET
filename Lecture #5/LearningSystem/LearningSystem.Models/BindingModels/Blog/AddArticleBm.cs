using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Models.BindingModels.Blog
{
    public class AddArticleBm
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
