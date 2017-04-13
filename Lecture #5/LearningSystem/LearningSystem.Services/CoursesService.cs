using AutoMapper;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
    public class CoursesService : Service, ICoursesService
    {
        public DetailsCourseVm GetCourseDetailsVm(int id)
        {
            var course = this.Context.Courses.Find(id);
            if (course == null)
            {
                return null;
            }

            var viewModel = Mapper.Map<Course, DetailsCourseVm>(course);

            return viewModel;
        }
    }
}
