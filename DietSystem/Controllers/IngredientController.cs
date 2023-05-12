using System.Net;
using DietSystem.Interfaces;
using DietSystem.Models;
using DietSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DietSystem.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientController(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Ingredient> ingredients = await _ingredientRepository.GetAll();
            return View(ingredients);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return View(ingredient);
            }
            _ingredientRepository.Add(ingredient);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            if (ingredient == null) return View("Error");
            var ingredientVM = new EditIngredientVM
            {
                Name = ingredient.Name,
                IngredientCategory = ingredient.IngredientCategory,
            };
            return View(ingredientVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditIngredientVM ingredientVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Faild to edit ingredient");
                return View("Edit", ingredientVM);
            }
            var ingredient = new Ingredient
            {
                Id = id,
                Name = ingredientVM.Name,
                IngredientCategory = ingredientVM.IngredientCategory
            };
            _ingredientRepository.Update(ingredient);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dishDetails = await _ingredientRepository.GetByIdAsync(id);
            if (dishDetails == null) return View("Error");
            return View(dishDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredientDetails = await _ingredientRepository.GetByIdAsync(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ingredientDetails == null)
            {
                return View("Error");
            }
            _ingredientRepository.Delete(ingredientDetails);
            return RedirectToAction("Index");
        }
    }
}