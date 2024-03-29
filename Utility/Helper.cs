﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwimmingPoolNew.Models;

namespace SwimmingPoolNew.Utility
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string Student = "Student";
        public static string Teacher = "Teacher";
        public static string appointmentAdded = "Appointment added successfully.";
        public static string appointmentUpdated = "Appointment updated successfully.";
        public static string appointmentDeleted = "Appointment deleted successfully.";
        public static string appointmentExists = "Appointment for selected date and time already exists.";
        public static string appointmentNotExists = "Appointment not exists.";
        public static string meetingConfirm = "Meeting confirm successfully.";
        public static string meetingConfirmError = "Error while confirming meeting.";
        public static string appointmentAddError = "Something went wront, Please try again.";
        public static string appointmentUpdatError = "Something went wront, Please try again.";
        public static string somethingWentWrong = "Something went wront, Please try again.";
        public static int success_code = 1;
        public static int failure_code = 0;

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            if (isAdmin)
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Admin,Text=Helper.Admin}
                };
            }
            else
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Student,Text=Helper.Student},
                    new SelectListItem{Value=Helper.Teacher,Text=Helper.Teacher}
                };
            }
        }

        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            duration.Add(new SelectListItem { Value = minute.ToString(), Text = "1 Hr" });
            duration.Add(new SelectListItem { Value = minute.ToString(), Text = "45 minutes" });
            //for (int i = 1; i <= 12; i++)
            //{
            //    duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr" });
            //    minute = minute + 30;
            //    duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr 30 min" });
            //    minute = minute + 30;
            //}
            return duration;
        }

        public static Boolean checkAppointment(Appointment apt)
        {
            bool isOk = true;
            int max = 2;
            if(true)
            {

                /// is listappointment.startDate == 2 || appointment1.typeclassId == appointment.typeclassId
                isOk = false;
                return isOk;
            }
            return isOk;
        }

    }
}