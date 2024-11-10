using System.ComponentModel.DataAnnotations;

namespace LossTracker.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Coordinates { get; set; }
    }
}
