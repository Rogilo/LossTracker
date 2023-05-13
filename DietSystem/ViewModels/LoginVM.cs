using System.ComponentModel.DataAnnotations;

namespace DietSystem.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email адреса")]
        [Required(ErrorMessage ="Введіть email адресу")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
