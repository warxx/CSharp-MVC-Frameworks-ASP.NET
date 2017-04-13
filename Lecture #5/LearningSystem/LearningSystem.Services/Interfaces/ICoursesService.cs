using LearningSystem.Models.ViewModels.Courses;

namespace LearningSystem.Services.Interfaces
{
    public interface ICoursesService
    {
        DetailsCourseVm GetCourseDetailsVm(int id);
    }
}