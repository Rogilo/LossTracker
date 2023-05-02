using System.ComponentModel.DataAnnotations;
using RunDietSystem.Data.Enum;

namespace DietSystem.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        /*public string? Ingredients { get; set; }*/
        public string? MethodOfCooking { get; set; }
        public DishCategory DishCategory { get; set; }
        public string? Image { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public List<DishIngredient> DishIngredients { get; } = new();
        public List<Meal> Meals { get; } = new();
        public List<MealDish> MealDishes { get; } = new();
    }
}
