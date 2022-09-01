using System;


namespace SwimmingPoolNew.Models
{
	public class Appointment
	{

		public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
		public string StyleId { get; set; }
		public string ClassTypeId { get; set; }
		public string TeacherId { get; set; }
        public string StudentId { get; set; }
		public bool IsTeacherApproved { get; set; }
		public string AdminId { get; set; }


    }

}

