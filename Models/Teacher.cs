using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace SwimmingPoolNew.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [DisplayName("Teacher Name")]
        [Required]
        public string TeacherName { get; set; } = string.Empty;
        [DisplayName("Style")]
        [Required]
        public string Style { get; set; } = string.Empty;
        [DisplayName("Available")]
        [Required]
        public DateTime Available { get; set; }
    }
}
