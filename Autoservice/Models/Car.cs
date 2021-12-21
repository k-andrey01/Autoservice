using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoservice.Models
{
    public class Car
    {
        public int CarID { get; set; }
        [Required]
        [Display(Name = "Марка")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Модель")]
        public string Model { get; set; }

        //public ICollection<Ccar> Ccars { get; set; }
        public ClientCar ClientCars { get; set; }
    }
}
