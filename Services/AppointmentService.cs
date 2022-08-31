using SwimmingPoolNew.Data;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using SwimmingPoolNew.Utility;
using SwimmingPoolNew.Models;
using System.Threading.Tasks;
using System;
using System.Reflection;
using  SwimmingPoolNew.Models.ViewModels;
namespace SwimmingPoolNew.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly SwimmingPoolContext _db;

        public AppointmentService(SwimmingPoolContext db)
        {
            _db = db;
        }

        public  async Task<int> AddUpdate(AppointmentVM model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.EndDate).AddMinutes(Convert.ToDouble(model.Duration));

            if(model != null && model.Id > 0)
            {
                var appointment = _db.Appintments.FirstOrDefault(x => x.Id == model.Id);

                //update
                appointment.StartDate = startDate;
                appointment.EndDate = endDate;
                appointment.Duration = model.Duration;
                appointment.styleId = model.styleId;
                appointment.classTypeId = model.classTypeId;
                appointment.TeacherId = model.TeacherId;
                appointment.StudentId = model.StudentId;
                appointment.IsTeacherApproved = false;
                appointment.AdminId = model.AdminId;
                await _db.SaveChangesAsync();
                return 1;
            }
            else
            {
                //create
                Appointment appointment = new Appointment()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                    styleId = model.styleId,
                    classTypeId = model.classTypeId,
                    TeacherId = model.TeacherId,
                    StudentId = model.StudentId,
                    IsTeacherApproved = model.IsTeacherApproved,
                    AdminId = model.AdminId
                };
                _db.Appintments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }
        }

        public async Task<int> ConfirmEvent(int id)
        {
            var appointment = _db.Appintments.FirstOrDefault(x => x.Id == id);
            if (appointment != null)
            {
                appointment.IsTeacherApproved = true;
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> Delete(int id)
        {
            var appointment = _db.Appintments.FirstOrDefault(x => x.Id == id);
            if (appointment != null)
            {
                _db.Appintments.Remove(appointment);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public List<AppointmentVM> TeachersEventsById(string teacherId)
        {
            return _db.Appintments.Where(x => x.TeacherId == teacherId).ToList().Select(c => new AppointmentVM()
            {
                Id = c.Id,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Duration = c.Duration,
                IsTeacherApproved = c.IsTeacherApproved
            }).ToList();
        }


        public AppointmentVM GetById(int id)
        {
            return _db.Appintments.Where(x => x.Id == id).ToList().Select(c => new AppointmentVM()
            {
                Id = c.Id,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Duration = c.Duration,
                IsTeacherApproved = c.IsTeacherApproved,
                StudentId = c.StudentId,
                TeacherId = c.TeacherId,
                StudentName = _db.Users.Where(x => x.Id == c.StudentId).Select(x => x.Name).FirstOrDefault(),
                TeacherName = _db.Users.Where(x => x.Id == c.TeacherId).Select(x => x.Name).FirstOrDefault(),
            }).SingleOrDefault();
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
            var styles = (from st in _db.Style
                          select new StyleVM
                          {
                              Id = st.StyleId,
                              Name = st.Name,
                          }).ToList();
          return styles;

        }

        public List<ClassTypeVM> GetClassTypeList()
        {
            var classes = (from clas in _db.TypeClass
                           select new ClassTypeVM
                           {
                               Id = clas.ClassId,
                                Name = clas.Name,
                           }).ToList();
           return classes;
        }

        public List<AppointmentVM> StudentEventsById(string studentId)
        {
            return _db.Appintments.Where(x => x.StudentId == studentId).ToList().Select(c => new AppointmentVM()
            {
                Id = c.Id,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Duration = c.Duration,
                IsTeacherApproved = c.IsTeacherApproved
            }).ToList();
        }

    }
}
