using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoservice.Models
{
    public class Master
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        [Display(Name = "Имя Отчество")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [Required]
        [Display(Name ="Стаж")]
        public double Stage { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role {get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }

        //public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}