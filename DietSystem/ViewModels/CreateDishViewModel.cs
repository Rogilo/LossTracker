using RunDietSystem.Data.Enum;

namespace RunDietSystem.ViewModels
{
    public class CreateDishViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Ingredients { get; set; }
        public string? MethodOfCooking { get; set; }
        public DishCategory DishCategory { get; set; }
        public IFormFile? Image { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
    }
}
