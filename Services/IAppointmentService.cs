using SwimmingPoolNew.Models.ViewModels;
using System.Collections.Generic;

namespace SwimmingPoolNew.Services
{
    public interface IAppointmentService
    {
        public List<StudentVM> GetStudentList();
        public List<TeacherVM> GetTeacherList();

    }
}
 