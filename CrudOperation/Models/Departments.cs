using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Models
{
    public class Departments
    {
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "ID")]
        [MaxLength(30, ErrorMessage = "Enter a valid ID")]
        public int ID { get; set; }
        public string Department { get; set; }


    }
}
