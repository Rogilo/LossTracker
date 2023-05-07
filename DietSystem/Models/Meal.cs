using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DietSystem.Data.Enum;

namespace DietSystem.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Ration")]
        public int? RationId { get; set; }
        public Ration? Ration { get; set; }
        public MealCategory MealCategory { get; set; }
        public List<MealDish>? MealDishes { get; set; }
    }
}
