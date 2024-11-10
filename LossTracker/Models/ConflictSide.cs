using System.ComponentModel.DataAnnotations;

namespace LossTracker.Models
{
    public class ConflictSide
    {
        [Key]
        public int SideId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
