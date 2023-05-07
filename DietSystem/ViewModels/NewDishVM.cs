using System.ComponentModel.DataAnnotations;
using DietSystem.Models;
using RunDietSystem.Data.Enum;

namespace RunDietSystem.ViewModels
{
    public class NewDishVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Method of cooking is required")]
        public string? MethodOfCooking { get; set; }
        [Required(ErrorMessage = "Category  is required")]
        public DishCategory DishCategory { get; set; }
        public string? URL { get; set; }
        public IFormFile? Image { get; set; }
        [Required(ErrorMessage = "Dish calories is required")]
        public double Calories { get; set; }
        [Required(ErrorMessage = "Dish proteins is required")]
        public double Proteins { get; set; }
        [Required(ErrorMessage = "Dish Fats is required")]
        public double Fats { get; set; }
        [Required(ErrorMessage = "Dish carbohydrates is required")]
        public double Carbohydrates { get; set; }

        //Relationships
        [Required(ErrorMessage = "Dish ingredient(s) is required")]
        public List<int> IngredientIds { get; set; }
    }
}
