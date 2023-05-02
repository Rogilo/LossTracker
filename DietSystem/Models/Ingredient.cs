using System.ComponentModel.DataAnnotations;
using DietSystem.Data.Enum;

namespace DietSystem.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public IngredientCategory IngredientCategory { get; set; }
        public List<DishIngredient> DishIngredients { get; } = new();
    }
}
