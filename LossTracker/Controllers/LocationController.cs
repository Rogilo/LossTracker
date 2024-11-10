using LossTracker.Interfaces;
using LossTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LossTracker.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // GET: All Locations
        public async Task<IActionResult> Index()
        {
            var locations = await _locationRepository.GetAllAsync();
            return View(locations);
        }

        // GET: Location Details
        public async Task<IActionResult> Details(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null) return NotFound();
            return View(location);
        }

        // GET: Add New Location
        public IActionResult Create()
        {
            return View();
        }

        // POST: Add New Location
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location location)
        {
            if (!ModelState.IsValid) return View(location);

            await _locationRepository.AddAsync(location);
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit Location
        public async Task<IActionResult> Edit(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null) return NotFound();

            return View(location);
        }

        // POST: Edit Location
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Location location)
        {
            if (id != location.LocationId || !ModelState.IsValid) return View(location);

            await _locationRepository.UpdateAsync(location);
            return RedirectToAction(nameof(Index));
        }

        // DELETE: Delete Location
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var location = _locationRepository.GetByIdAsync(id).Result;
            if (location == null) return NotFound();

            _locationRepository.Delete(location);
            _locationRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
