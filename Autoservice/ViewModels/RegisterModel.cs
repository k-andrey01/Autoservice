using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoservice.ViewModels
{
    public class RegisterModel
    {
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        [Required]
        public string LastName { get; set; }
        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name = "Имя Отчество")]
        [Required]
        public string FirstMidName { get; set; }
        [Display(Name = "Номер телефона")]
        [Required]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}
