using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LearningSystem.Models.BindingModels.Users;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Models.ViewModels.Users;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
    public class UsersService : Service, IUsersService
    {
        public Student GetCurrentStudent(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.UserName == userName);
            var student = this.Context.Students.FirstOrDefault(x => x.User.Id == user.Id);
            return student;
        }

        public void EnrollStudentInCourse(int courseId, Student student)
        {
            var wantedCourse = this.Context.Courses.Find(courseId);
            student.Courses.Add(wantedCourse);
            this.Context.SaveChanges();
        }

        public UserProfileVm GetProfileVm(string userName)
        {
            var currentUser = this.Context.Users.FirstOrDefault(x => x.UserName == userName);
            var viewModel = Mapper.Map<ApplicationUser, UserProfileVm>(currentUser);
            var student = this.Context.Students.FirstOrDefault(x => x.User.Id == currentUser.Id);

            viewModel.EnrolledCourses = Mapper.Map<IEnumerable<Course>, IEnumerable<UserCourseVm>>(student.Courses);
            return viewModel;
        }

        public EditUsersVm GetEditUserVm(string userName)
        {
            var currentUser = this.Context.Users.FirstOrDefault(x => x.UserName == userName);
            var viewModel = Mapper.Map<ApplicationUser, EditUsersVm>(currentUser);
            return viewModel;
        }

        public void EditUserFromBm(string currentUserName, EditUserBm model)
        {
            var currentUser = this.Context.Users.FirstOrDefault(x => x.UserName == currentUserName);
            currentUser.Name = model.Name;
            currentUser.Email = model.Email;
            this.Context.SaveChanges();
        }
    }
}
