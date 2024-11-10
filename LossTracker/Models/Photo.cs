using System.ComponentModel.DataAnnotations;

namespace LossTracker.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        // Foreign Key for Loss
        public int LossId { get; set; }
    }
}
