using DietSystem.Models;

namespace RunDietSystem.Interfaces
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAll();
        Task<Dish> GetByIdAsync(int id);
        bool Add(Dish dish);
        bool Update(Dish dish);
        bool Delete(Dish dish);
        bool Save();


    }
}
