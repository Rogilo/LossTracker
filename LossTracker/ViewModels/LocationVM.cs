using System.ComponentModel.DataAnnotations;

namespace LossTracker.ViewModels
{
    public class LocationVM
    {
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Введіть назву локації")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Введіть координати локації")]
        public string? Coordinates { get; set; }
    }
}