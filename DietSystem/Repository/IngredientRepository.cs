using DietSystem.Data;
using DietSystem.Interfaces;
using DietSystem.Models;
using Microsoft.EntityFrameworkCore;
using RunDietSystem.Interfaces;

namespace DietSystem.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context)
        {

            _context = context;
        }

        public bool Add(Ingredient ingredient)
        {
            _context.Add(ingredient);
            return Save();
        }

        public bool Delete(Ingredient ingredient)
        {
            _context.Remove(ingredient);
            return Save();
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Ingredient ingredient)
        {
            _context.Update(ingredient);
            return Save();
        }
    }
}
