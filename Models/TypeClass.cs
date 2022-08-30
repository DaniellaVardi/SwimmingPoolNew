using System;
using System.ComponentModel.DataAnnotations;

namespace SwimmingPoolNew.Models
{
    public class TypeClass
    {
        [Key]
        public int ClassId { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public DateTime Time { get; set; }
    }
}
