using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoservice.Models
{
    public class Client
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name = "Имя Отчество")]
        [Required]
        public string FirstMidName { get; set; }
        [Display(Name = "Номер телефона")]
        [Required]
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        [Display(Name = "Полное имя")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }


        /*public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Request> Requests { get; set; }*/
        public ICollection<Request> Requests { get; set; }
    }
}
