
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
    public class AdminService : Service, IAdminService
    {
        public IndexVm GetIndexPageVm()
        {
            var page = new IndexVm();

            var courses = this.Context.Courses.ToList();
            var student = this.Context.Students.ToList();

            var courseVms = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseVm>>(courses);
            var studentVms = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentVm>>(student);

            page.Courses = courseVms;
            page.Students = studentVms;

            return page;
        }
    }
}
