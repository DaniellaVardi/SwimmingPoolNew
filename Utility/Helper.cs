using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SwimmingPoolNew.Utility
{
    public class Helper
    {

        public static string Admin = "Admin";
        public static string Teacher = "Teacher";
        public static string Student = "Student";

        public static List<SelectListItem> GetRolesDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value=Helper.Admin,Text=Helper.Admin},
                new SelectListItem{Value=Helper.Teacher,Text=Helper.Teacher},
                new SelectListItem{Value=Helper.Student,Text=Helper.Student},
            };
        }

         public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr" });
                minute = minute + 45;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr 45 min" });
                minute = minute + 45;
            }
            return duration;
        }
    }
}
