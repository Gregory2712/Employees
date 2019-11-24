namespace Employees.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="First Name/s")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [StringLength(11)]
       
        public string Phone { get; set; }
        [EmailAddress]
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        //[Display(Name ="Persal no")]
        //public string PersalNo { get; set; }


    }
}
