using LearningSystem.Models.BindingModels.Users;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Users;

namespace LearningSystem.Services.Interfaces
{
    public interface IUsersService
    {
        Student GetCurrentStudent(string userName);
        void EnrollStudentInCourse(int courseId, Student student);
        UserProfileVm GetProfileVm(string userName);
        EditUsersVm GetEditUserVm(string userName);
        void EditUserFromBm(string currentUserName, EditUserBm model);
    }
}