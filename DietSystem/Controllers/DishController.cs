using DietSystem.Models;
using DietSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RunDietSystem.Interfaces;
using RunDietSystem.ViewModels;

namespace RunDietSystem.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishRepository _dishrepository;
        private readonly IPhotoService _photoService;
        public DishController(IDishRepository dishRepository, IPhotoService photoService)
        {
            _dishrepository = dishRepository;
            _photoService = photoService;

        }

        public async Task<IActionResult> Index()
        {
            /*var ingredientdata = Ingredient.GetAll();*/
            IEnumerable<Dish> dishes = await _dishrepository.GetAll();
            return View(dishes);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Dish dish = await _dishrepository.GetByIdAsync(id);
            return View(dish);
        }

        public IActionResult Create () 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDishViewModel dishVM)
        {
            if (!ModelState.IsValid)
            {
                var photoResult = await _photoService.AddPhotoAsync(dishVM.Image);
                var dish = new Dish
                {
                    Name = dishVM.Name,
                  /*  Ingredients = dishVM.Ingredients,*/
                    MethodOfCooking = dishVM.MethodOfCooking,
                    DishCategory = dishVM.DishCategory,
                    Image = photoResult.Url.ToString(),
                    Calories = dishVM.Calories,
                    Proteins = dishVM.Proteins,
                    Fats = dishVM.Fats,
                    Carbohydrates = dishVM.Carbohydrates
                };
                _dishrepository.Add(dish);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload fail");
            }
            return View(dishVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dish = await _dishrepository.GetByIdAsync(id);
            if(dish == null) return View("Error");
            var dishVM = new EditDishViewModel
            {
                Name = dish.Name,
              /*  Ingredients = dish.Ingredients,*/
                MethodOfCooking = dish.MethodOfCooking,
                DishCategory = dish.DishCategory,
                URL = dish.Image,
                Calories = dish.Calories,
                Proteins = dish.Proteins,
                Fats = dish.Fats,
                Carbohydrates = dish.Carbohydrates
            };
            return View(dishVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditDishViewModel dishVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit dish");
                return View("Edit",dishVM);
            }

            var photoResult = await _photoService.AddPhotoAsync(dishVM.Image);
            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(dishVM);
            }

            var dish = new Dish
            {
                Id = id,
                Name = dishVM.Name,
          /*      Ingredients = dishVM.Ingredients,*/
                MethodOfCooking = dishVM.MethodOfCooking,
                DishCategory = dishVM.DishCategory,
                Image = photoResult.Url.ToString(),
                Calories = dishVM.Calories,
                Proteins = dishVM.Proteins,
                Fats = dishVM.Fats,
                Carbohydrates = dishVM.Carbohydrates
            };
            _dishrepository.Update(dish);

            return RedirectToAction("Index");

        }
    }
}
  