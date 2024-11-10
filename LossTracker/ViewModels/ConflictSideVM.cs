using System.ComponentModel.DataAnnotations;

namespace LossTracker.ViewModels
{
    public class ConflictSideVM
    {
        public int SideId { get; set; }

        [Required(ErrorMessage = "Введіть назву сторони конфлікту")]
        public string? Name { get; set; }
    }
}