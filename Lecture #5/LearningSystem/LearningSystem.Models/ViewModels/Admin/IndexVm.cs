using System.Collections.Generic;
using LearningSystem.Models.ViewModels.Courses;

namespace LearningSystem.Models.ViewModels.Admin
{
    public class IndexVm
    {
        public IEnumerable<CourseVm> Courses { get; set; }

        public IEnumerable<StudentVm> Students { get; set; }
    }
}
