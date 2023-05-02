using DietSystem.Data;
using DietSystem.Models;
using Microsoft.EntityFrameworkCore;
using RunDietSystem.Interfaces;

namespace RunDietSystem.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _context;
        public DishRepository(ApplicationDbContext context) {

            _context = context;
        } 
        public bool Add(Dish dish)
        {
            _context.Add(dish);
            return Save();
        }

        public bool Delete(Dish dish)
        {
            _context.Remove(dish);
            return Save();
        }

        public async Task<IEnumerable<Dish>> GetAll()
        {
            return await _context.Dishes.ToListAsync();

        }

        public async Task<Dish> GetByIdAsync(int id)
        {
            return await _context.Dishes.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Dish dish)
        {
            _context.Update(dish);
            return Save();
        }
    }
}
