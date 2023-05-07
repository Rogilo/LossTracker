using System.ComponentModel.DataAnnotations.Schema;

namespace DietSystem.Models
{
    public class DishIngredient
    {
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        [ForeignKey("Dish")]
        public int DishId { get; set; }

        public  Ingredient Ingredient { get; set; }
        public  Dish Dish { get; set; }
    }
}
 