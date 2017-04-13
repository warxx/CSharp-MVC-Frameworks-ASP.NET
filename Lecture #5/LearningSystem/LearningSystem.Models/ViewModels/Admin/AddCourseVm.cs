using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Models.ViewModels.Admin
{
    public class AddCourseVm
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [Required]
        public DateTime EndDate { get; set; }
    }
}
