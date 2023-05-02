using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietSystem.Models
{
    public class Ration
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AppUser")]
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? RationName { get; set; }
    }
}
