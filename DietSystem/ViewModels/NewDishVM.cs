using System.ComponentModel.DataAnnotations;
using DietSystem.Models;
using RunDietSystem.Data.Enum;

namespace RunDietSystem.ViewModels
{
    public class NewDishVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введіть назву страви")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Введіть спосіб приготування страви")]
        public string? MethodOfCooking { get; set; }
        [Required(ErrorMessage = "Виберіть категорію")]
        public DishCategory DishCategory { get; set; }
        public string? URL { get; set; }
        [Required(ErrorMessage = "Виберіть фото страви")]
        public IFormFile? Image { get; set; }
        [Required(ErrorMessage = "Введіть калорійність страв")]
        public double Calories { get; set; }
        [Required(ErrorMessage = "Введіть кількість білків в страві")]
        public double Proteins { get; set; }
        [Required(ErrorMessage = "Введіть кількість жирів в страві")]
        public double Fats { get; set; }
        [Required(ErrorMessage = "Введіть кількість вуглеводів в страві")]
        public double Carbohydrates { get; set; }

        //Relationships
        [Required(ErrorMessage = "Виберіть склад інгрідієнтів страви")]
        public List<int> IngredientIds { get; set; }
    }
}
