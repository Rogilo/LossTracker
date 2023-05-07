using DietSystem.Models;

namespace DietSystem.ViewModels
{
    public class NewDishDropdownsVM
    {
        public NewDishDropdownsVM()
        {
            Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; set; }
    }
}
