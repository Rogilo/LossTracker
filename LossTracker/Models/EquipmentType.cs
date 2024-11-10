using System.ComponentModel.DataAnnotations;

namespace LossTracker.Models
{
    public class EquipmentType
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
