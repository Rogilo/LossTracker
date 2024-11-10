using System.ComponentModel.DataAnnotations;

namespace LossTracker.ViewModels
{
    public class EquipmentTypeVM
    {
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Введіть назву типу техніки")]
        public string? Name { get; set; }
    }
}