using LearningSystem.Models.EntityModels;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
    public class AccountService : Service, IAccountService
    {
        public void CreateStudent(ApplicationUser user)
        {
            var student = new Student();
            var currentUser = this.Context.Users.Find(user.Id);
            student.User = currentUser;
            this.Context.Students.Add(student);
            this.Context.SaveChanges();
        }
    }
}
