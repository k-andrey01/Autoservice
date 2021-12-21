using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoservice.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        [Display(Name = "Клиент")]
        [Required]
        public int ClientId { get; set; }
        [Display(Name = "Мастер")]
        [Required]
        public int MasterId { get; set; }
        [Display(Name = "Автомобиль")]
        [Required]
        public int ClientCarId { get; set; }

        [Display(Name = "Дата подачи заявки")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Display(Name = "Стоимость")]
        [Required]
        public int Price { get; set; }

        /*public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Client> Clients { get; set; }*/
        [Display(Name = "Клиент")]
        public Client Clients { get; set; }
        [Display(Name = "Мастер")]
        public Master Masters { get; set; }
        [Display(Name = "Автомобиль")]
        public ClientCar ClientCars { get; set; }
    }
}
