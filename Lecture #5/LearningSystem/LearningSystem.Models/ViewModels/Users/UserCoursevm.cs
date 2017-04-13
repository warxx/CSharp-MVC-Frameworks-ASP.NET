using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using LearningSystem.Models.Enums;

namespace LearningSystem.Models.ViewModels.Users
{
    public class UserCourseVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public Grade Grade { get; set; }
    }
}
