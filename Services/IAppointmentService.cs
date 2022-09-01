using SwimmingPoolNew.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwimmingPoolNew.Models;

namespace SwimmingPoolNew.Services
{
    public interface IAppointmentService
    {
        public List<StudentVM> GetStudentList();
        public List<TeacherVM> GetTeacherList();
        public List<ClassTypeVM> GetClassTypeList();
        public List<StyleVM> GetStyleList();

        public List<AppointmentVM> GetAppointmentList();
        public Task<int> AddUpdate(AppointmentVM model);

        public List<AppointmentVM> TeachersEventsById(string teacherId);

        public List<AppointmentVM> StudentEventsById(string studentId);

        public AppointmentVM GetById(int id);

        public Task<int> Delete(int id);

        public Task<int> ConfirmEvent(int id);

    }
}
 