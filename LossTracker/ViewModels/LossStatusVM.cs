using System.ComponentModel.DataAnnotations;

namespace LossTracker.ViewModels
{
    public class LossStatusVM
    {
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Введіть назву статусу втрати")]
        public string? Name { get; set; }
    }
}