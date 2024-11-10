using System.ComponentModel.DataAnnotations;

namespace LossTracker.Models
{
    public class LossStatus
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
