using SwimmingPoolNew.Models.ViewModels;
using System.Collections.Generic;

namespace SwimmingPoolNew.Services
{
    public interface IAppointmentService
    {
        public List<StudentVM> GetStudentList();
        public List<TeacherVM> GetTeacherList();
        public List<ClassTypeVM> GetClassTypeList();
        public List<StyleVM> GetStyleList();

    }
}
 