using DietSystem.Data.Enum;

namespace DietSystem.ViewModels
{
    public class EditIngredientVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IngredientCategory IngredientCategory { get; set; }
    }
}
