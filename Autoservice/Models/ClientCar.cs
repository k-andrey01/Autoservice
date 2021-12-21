using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoservice.Models
{
    public class ClientCar
    {
        public int ClientCarID { get; set; }
        [Required]
        [Display(Name = "Автомобиль")]
        public int CarID { get; set; }
        [Required]
        [Display(Name = "Номер автомобиля")]
        public string Number { get; set; }
        [Required]
        [Display(Name = "Год выпуска")]
        public int Year { get; set; }

       /* public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Ccar> Ccars { get; set; }*/
        public Car Cars { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
