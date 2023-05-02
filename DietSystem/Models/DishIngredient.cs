using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietSystem.Models
{
    public class DishIngredient
    {

        [Key]
        public int Id { get; set; }
        [ForeignKey("Ingredient")]
        public int? IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        [ForeignKey("Dish")]
        public int? DishId { get; set; }
        public Dish? Dish { get; set; }
    }
}
