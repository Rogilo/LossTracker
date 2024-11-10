using LossTracker.Data;
using LossTracker.Interfaces;
using LossTracker.Models;
using LossTracker.ViewModel;
using LossTracker.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LossTracker.Repository
{
    public class LossRepository : ILossRepository
    {
        private readonly ApplicationDbContext _context;

        public LossRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loss>> GetAllAsync()
        {
            return await _context.Losses
                .Include(l => l.EquipmentType)
                .Include(l => l.LossStatus)
                .Include(l => l.Location)
                .Include(l => l.Tags)
                .ToListAsync();
        }

        public async Task<Loss> GetByIdAsync(int id)
        {
            return await _context.Losses
                .Include(l => l.EquipmentType)
                .Include(l => l.LossStatus)
                .Include(l => l.Location)
                .Include(l => l.Tags)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Loss>> FilterLossAsync(LossSearchVM searchParameters)
        {
            var query = _context.Losses
                .Include(l => l.EquipmentType)
                .Include(l => l.LossStatus)
                .Include(l => l.Location)
                .Include(l => l.Tags)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchParameters.Name))
                query = query.Where(l => l.Name.Contains(searchParameters.Name));
            if (searchParameters.EquipmentTypeId.HasValue)
                query = query.Where(l => l.EquipmentTypeId == searchParameters.EquipmentTypeId);
            if (searchParameters.LossStatusId.HasValue)
                query = query.Where(l => l.LossStatusId == searchParameters.LossStatusId);
            if (searchParameters.LocationId.HasValue)
                query = query.Where(l => l.LocationId == searchParameters.LocationId);

            return await query.ToListAsync();
        }

        public async Task AddAsync(NewLossVM data)
        {
            var newLoss = new Loss
            {
                Name = data.Name,
                EquipmentTypeId = data.EquipmentTypeId,
                LossStatusId = data.LossStatusId,
                LocationId = data.LocationId,
                Date = data.Date
            };
            _context.Losses.Add(newLoss);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EditLossVM data)
        {
            var existingLoss = await _context.Losses.FindAsync(data.Id);
            if (existingLoss != null)
            {
                existingLoss.Name = data.Name;
                existingLoss.EquipmentTypeId = data.EquipmentTypeId;
                existingLoss.LossStatusId = data.LossStatusId;
                existingLoss.LocationId = data.LocationId;
                existingLoss.Date = data.Date;
                await _context.SaveChangesAsync();
            }
        }

        public bool Delete(Loss loss)
        {
            _context.Losses.Remove(loss);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return _context.Losses.Any(l => l.Id == id);
        }
    }
}
