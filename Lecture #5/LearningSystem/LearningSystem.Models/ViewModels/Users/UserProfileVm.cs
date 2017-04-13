using System;
using System.Collections.Generic;

namespace LearningSystem.Models.ViewModels.Users
{
    public class UserProfileVm
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public IEnumerable<UserCourseVm> EnrolledCourses { get; set; }
        
    }
}
