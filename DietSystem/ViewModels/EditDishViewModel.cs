using DietSystem.Models;
using RunDietSystem.Data.Enum;

namespace DietSystem.ViewModels
{
    public class EditDishViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MethodOfCooking { get; set; }
        public DishCategory DishCategory { get; set; }
        public IFormFile? Image { get; set; }
        public string? URL { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public List<DishIngredient> DishIngredients { get; } = new();
    }
}
