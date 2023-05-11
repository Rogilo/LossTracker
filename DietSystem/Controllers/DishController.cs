using DietSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RunDietSystem.Data.Enum;
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

        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = await _dishrepository.GetByNameAsync(searchString);
            return View(dishes);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Dish dish = await _dishrepository.GetByIdAsync(id);
            return View(dish);
        }

        public async Task<IActionResult> Create()
        {
            var dishDropdownsData = await _dishrepository.GetNewDishDropdownsValues();

            ViewBag.Ingredients = new SelectList(dishDropdownsData.Ingredients, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewDishVM dishVM)
        {
            if (!ModelState.IsValid)
            {
                var dishDropdownsData = await _dishrepository.GetNewDishDropdownsValues();

                ViewBag.Ingredients = new SelectList(dishDropdownsData.Ingredients, "Id", "Name");

                return View(dishVM);
            }

            await _dishrepository.Add(dishVM);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dishDetails = await _dishrepository.GetByIdAsync(id);
            if (dishDetails == null) return View("NotFound");

            var response = new NewDishVM()
            {
                Name = dishDetails.Name,
                MethodOfCooking = dishDetails.MethodOfCooking,
                DishCategory = dishDetails.DishCategory,
                URL = dishDetails.Image,
                Calories = dishDetails.Calories,
                Proteins = dishDetails.Proteins,
                Fats = dishDetails.Fats,
                Carbohydrates = dishDetails.Carbohydrates,
                IngredientIds = dishDetails.DishIngredients.Select(n => n.IngredientId).ToList(),
            };

            var dishDropdownsData = await _dishrepository.GetNewDishDropdownsValues();
            ViewBag.Ingredients = new SelectList(dishDropdownsData.Ingredients, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewDishVM dishVM)
        {
            if (id != dishVM.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit dish");
                return View("Edit", dishVM);
            }
            if (!ModelState.IsValid)
            {
                var dishDropdownsData = await _dishrepository.GetNewDishDropdownsValues();

                ViewBag.Ingredients = new SelectList(dishDropdownsData.Ingredients, "Id", "Name");

                return View(dishVM);
            }

            await _dishrepository.Update(dishVM);

            return RedirectToAction("Index");

        }
    }
}
