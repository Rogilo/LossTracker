using CloudinaryDotNet.Actions;
using DietSystem.Data;
using DietSystem.Models;
using DietSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using RunDietSystem.Data.Enum;
using RunDietSystem.Interfaces;
using RunDietSystem.ViewModels;

namespace RunDietSystem.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;
        public DishRepository(ApplicationDbContext context, IPhotoService photoService) {

            _context = context;
            _photoService = photoService;
        } 
        public async Task Add(NewDishVM data)
        {
            var photoResult = await _photoService.AddPhotoAsync(data.Image);
            var newDish = new Dish
            {
                Name = data.Name,
                MethodOfCooking = data.MethodOfCooking,
                DishCategory = data.DishCategory,
                Image = photoResult.Url.ToString(),
                Calories = data.Calories,
                Proteins = data.Proteins,
                Fats = data.Fats,
                Carbohydrates = data.Carbohydrates
            };
            await _context.Dishes.AddAsync(newDish);
            await _context.SaveChangesAsync();

            //Add dish ingredients
            foreach (var ingredientId in data.IngredientIds)
            {
                var newDishIngredient = new DishIngredient()
                {
                    DishId = newDish.Id,
                    IngredientId = ingredientId
                };
                await _context.DishIngredients.AddAsync(newDishIngredient);
            }
            await _context.SaveChangesAsync();
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
            var dishDetail = await _context.Dishes
                .Include(c => c.DishIngredients).ThenInclude(a => a.Ingredient)
                .FirstOrDefaultAsync(n => n.Id == id);
            return dishDetail;
        }
        public async Task<IEnumerable<Dish>> FilterDishAsync(string searchString, DishCategory dishCategory)
        {
            var dishes = from m in _context.Dishes
                         select m;
            if (searchString != null && searchString != "")
            {
                dishes = dishes.Where(s => s.Name!.Contains(searchString));
            }
            if (dishCategory.ToString() != null && (dishCategory.ToString() != "" && dishCategory.ToString() != "Any"))
            {
                dishes = dishes.Where(x => x.DishCategory == dishCategory);
            }
            return await dishes.ToListAsync();
        }

        public async Task<NewDishDropdownsVM> GetNewDishDropdownsValues()
        {
            var response = new NewDishDropdownsVM()
            {
                Ingredients = await _context.Ingredients.OrderBy(n => n.Name).ToListAsync(),
            };

            return response;
        }
        public async Task Update(NewDishVM data)
        {
            var dbDish = await _context.Dishes.FirstOrDefaultAsync(n => n.Id == data.Id);
            var photoResult = await _photoService.AddPhotoAsync(data.Image);
            await _context.SaveChangesAsync();
            if (dbDish != null)
            {
                dbDish.Name = data.Name;    
                dbDish.MethodOfCooking = data.MethodOfCooking;
                dbDish.DishCategory = data.DishCategory;
                dbDish.Image = photoResult.Url.ToString();
                dbDish.Calories = data.Calories;
                dbDish.Proteins = data.Proteins;
                dbDish.Fats = data.Fats;
                dbDish.Carbohydrates = data.Carbohydrates;
                await _context.SaveChangesAsync();
            }
            // Remove existing ingredients
            var existingActorsDb = _context.DishIngredients.Where(n => n.Dish.Id == data.Id).ToList();
            _context.DishIngredients.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add dish ingredients
            foreach (var ingredientId in data.IngredientIds)
            {
                var newActorMovie = new DishIngredient()
                {
                    DishId = data.Id,
                    IngredientId = ingredientId
                };
                await _context.DishIngredients.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Dishes.Any(i => i.Id == id);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
