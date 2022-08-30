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
    }
}
