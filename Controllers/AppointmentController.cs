using Microsoft.AspNetCore.Mvc;
using SwimmingPoolNew.Services;
using SwimmingPoolNew.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SwimmingPoolNew.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;

        }

        public IActionResult Index()
        {
            ViewBag.TeacherList = _appointmentService.GetTeacherList();
            ViewBag.StudentList = _appointmentService.GetStudentList();
            ViewBag.TypeClassList = _appointmentService.GetClassTypeList();
            ViewBag.StyleList = _appointmentService.GetStyleList();
            ViewBag.Duration = Helper.GetTimeDropDown();

            return View();
        }
    }
}
