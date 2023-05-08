using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietSystem.Models
{
    public class Ration
    {
        [Key]
        public int Id { get; set; }
        public string RationName { get; set; }

        // Relationships
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Meal> Meals { get; set; }
    }
}
