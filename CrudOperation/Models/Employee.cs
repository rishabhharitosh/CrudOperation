using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Models
{
    public class Employee
    {
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "Enter a valid name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(15, ErrorMessage = "enter a valid mobile number")]
        public string Mobile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "Enter a valid Email")]
        [EmailAddress]
        public string Email { get; set; }
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "DepID")]
        [MaxLength(50, ErrorMessage = "Enter a valid ID")]
        public string DepartmentID { get; set; }

        [NotMapped]
        public string Department { get; set; }


    }
}
