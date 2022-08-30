using System;
using System.ComponentModel.DataAnnotations;

namespace SwimmingPoolNew.Models
{
    public class Style
    {
        [Key]
        public int StyleId { get; set; }

        [Required]
        public String Name { get; set; }

    }
}
