using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCPASEX1.Models
{
    public class Department
    {
        [Required]
        [Display(Name = "Enter Department Number")]
        public int dno { get; set; }


        [Required]
        [Display(Name = "Enter Department Name")]
        public string dname { get; set; }

        [Required]
        [Display(Name = "Enter Department City")]
        public string City { get; set; }


    }
}