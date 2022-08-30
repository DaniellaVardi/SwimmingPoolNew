using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
/*First Commit*/
namespace SwimmingPoolNew.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string StudentFirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string StudentLastName { get; set; }
        [DisplayName("Type Class")]
        [Required]
        public virtual TypeClass TypeClass{ get; set; }
        [DisplayName("Type Style")]
        [Required]
        public string TypeStyle { get; set; }


    }
}
