using DietSystem.Models;
using DietSystem.ViewModels;
using RunDietSystem.Data.Enum;
using RunDietSystem.ViewModels;

namespace RunDietSystem.Interfaces
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAll();
        Task<Dish> GetByIdAsync(int id);
        Task<NewDishDropdownsVM> GetNewDishDropdownsValues();
        Task<IEnumerable<Dish>> FilterDishAsync(string searchString, DishCategory dishCategory);
        Task Add(NewDishVM data);
        Task Update(NewDishVM dish);
        bool Delete(Dish dish);
        bool Save();
        bool Exists(int id);
    }
}
