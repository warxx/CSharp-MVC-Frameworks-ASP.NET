using System.Collections.Generic;
using AutoMapper;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
    public class HomeService : Service, IHomeService
    {
        public IEnumerable<CourseVm> GetAllCourses()
        {
            var courses = this.Context.Courses;
            var viewModels = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseVm>>(courses);

            return viewModels;
        }
    }
}
