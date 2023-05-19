using DietSystem.Data;
using DietSystem.Interfaces;
using DietSystem.Models;
using Microsoft.EntityFrameworkCore;
using RunDietSystem.Data.Enum;
using RunDietSystem.Interfaces;
using System.Security.Claims;

namespace DietSystem.Repository
{
    public class RationRepository : IRationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RationRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {

            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Dish>> FindByNameAsync(string searchString)
        {
            var dishes = from m in _context.Dishes
                         select m;
            if (searchString != null && searchString != "")
            {
                dishes = dishes.Where(s => s.Name!.Contains(searchString));
            }
            return await dishes.ToListAsync();
        }
        public Task Add(Ration ration)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Ration ration)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ration>> GetAll()
        {
            var rationDetail = await _context.Rations
               .Include(a => a.Meals)
               .ThenInclude(b => b.MealDishes)
               .ThenInclude(c => c.Dish)
               .ToListAsync();
            return rationDetail;
        }

        public async Task<Ration> GetByUserIdAsync()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var rationDetail = await _context.Rations
                .Include(a => a.Meals)
                .ThenInclude(b => b.MealDishes)
                .ThenInclude(c => c.Dish)
                .FirstOrDefaultAsync(n => n.AppUser.Id == curUser);
            return rationDetail;
        }
        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(Ration ration)
        {
            throw new NotImplementedException();
        }
    }
}
