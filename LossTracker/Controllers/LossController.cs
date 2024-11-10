using LossTracker.Interfaces;
using LossTracker.Models;
using LossTracker.ViewModel;
using LossTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LossTracker.Controllers
{
    public class LossController : Controller
    {
        private readonly ILossRepository _lossRepository;

        public LossController(ILossRepository lossRepository)
        {
            _lossRepository = lossRepository;
        }

        // GET: All Losses
        public async Task<IActionResult> Index()
        {
            var losses = await _lossRepository.GetAllAsync();
            return View(losses);
        }

        // GET: Loss Details
        public async Task<IActionResult> Details(int id)
        {
            var loss = await _lossRepository.GetByIdAsync(id);
            if (loss == null) return NotFound();
            return View(loss);
        }

        // GET: Add New Loss
        public IActionResult Create()
        {
            return View();
        }

        // POST: Add New Loss
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewLossVM newLoss)
        {
            if (!ModelState.IsValid) return View(newLoss);

            await _lossRepository.AddAsync(newLoss);
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit Loss
        public async Task<IActionResult> Edit(int id)
        {
            var loss = await _lossRepository.GetByIdAsync(id);
            if (loss == null) return NotFound();

            var editLossVM = new EditLossVM
            {
                Id = loss.Id,
                Name = loss.Name,
                EquipmentTypeId = loss.EquipmentTypeId,
                LossStatusId = loss.LossStatusId,
                LocationId = loss.LocationId,
                Date = loss.Date,
                TagIds = loss.Tags.Select(t => t.TagId).ToList()
            };

            return View(editLossVM);
        }

        // POST: Edit Loss
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditLossVM editLoss)
        {
            if (id != editLoss.Id || !ModelState.IsValid) return View(editLoss);

            await _lossRepository.UpdateAsync(editLoss);
            return RedirectToAction(nameof(Index));
        }

        // DELETE: Delete Loss
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var loss = _lossRepository.GetByIdAsync(id).Result;
            if (loss == null) return NotFound();

            _lossRepository.Delete(loss);
            _lossRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
