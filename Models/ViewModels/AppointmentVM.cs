using Microsoft.AspNetCore.Identity;
using System;

namespace SwimmingPoolNew.Models.ViewModels
{
    public class AppointmentVM
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Duration { get; set; }
        public string StyleId { get; set; }
        public string ClassTypeId { get; set; }
        public string TeacherId { get; set; }
        public string StudentId { get; set; }
        public bool IsTeacherApproved { get; set; }
        public string AdminId { get; set; }

        public string TeacherName { get; set; }
        public string StudentName { get; set; }
        public string ClassTypeName { get; set; }
        public string StyleName { get; set; }
        public string AdminName { get; set; }
        public bool IsForStudent { get; set; }

    }
}
