using SwimmingPoolNew.Data;
using SwimmingPoolNew.Models.ViewModels;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using SwimmingPoolNew.Utility;

namespace SwimmingPoolNew.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly SwimmingPoolContext _db;

        public AppointmentService(SwimmingPoolContext db)
        {
            _db = db;
        }
        public List<TeacherVM> GetTeacherList()
        {
            var teachers = (from user in _db.Users
                            join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                            join roles in _db.Roles.Where(x=>x.Name==Helper.Teacher) on userRoles.RoleId equals roles.Id
                            select new TeacherVM
                            {
                                Id = user.Id,
                                Name= user.Name,
                            } 
                            ).ToList();
            return teachers;
        }

        public List<StudentVM> GetStudentList()
        {
            var students = (from user in _db.Users
                            join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                            join roles in _db.Roles.Where(x => x.Name == Helper.Student) on userRoles.RoleId equals roles.Id
                            select new StudentVM
                            {
                                Id = user.Id,
                                Name = user.Name,
                            }
                            ).ToList();
            return students;
        }

        public List<StyleVM> GetStyleList()
        {

            var styles = {"rowing", "breast", "back","butterfly"};
            return styles;
        }

        public List<ClassTypeVM> GetClassTypeList()
        {
            var classTypes = {"private", "group"};
            return classTypes;
        }

    }
}
