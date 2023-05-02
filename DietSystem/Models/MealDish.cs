using System.ComponentModel.DataAnnotations.Schema;

namespace DietSystem.Models
{
    public class MealDish
    {
        [ForeignKey("Meal")]
        public int? MealId { get; set; }
        public Meal? Meal { get; set; }
        [ForeignKey("Dish")]
        public int? MDishId { get; set; }
        public Ration? MDish { get; set; }
    }
}
