using DietSystem.Interfaces;
using DietSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RunDietSystem.Interfaces;
using RunDietSystem.Repository;
using RunDietSystem.ViewModels;

namespace RunDietSystem.Controllers
{
    public class RationController : Controller
    {
        private readonly IRationRepository _rationRepository;
        public RationController(IRationRepository rationRepository)
        {
            _rationRepository = rationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userRation = await _rationRepository.GetByUserIdAsync();
            if (userRation == null) return View("Create");
            return View(userRation);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewDishVM dishVM)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
