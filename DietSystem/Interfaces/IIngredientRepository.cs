using DietSystem.Models;

namespace DietSystem.Interfaces
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetAll();
        Task<Ingredient> GetByIdAsync(int id);
        bool Add(Ingredient ingredient);
        bool Update(Ingredient ingredient);
        bool Delete(Ingredient ingredient);
        bool Save();
    }
}
