using LossTracker.Data;
using LossTracker.Interfaces;
using LossTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LossTracker.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task AddAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Location location)
        {
            var existingLocation = await _context.Locations.FindAsync(location.LocationId);
            if (existingLocation != null)
            {
                existingLocation.Name = location.Name;
                existingLocation.Coordinates = location.Coordinates;
                await _context.SaveChangesAsync();
            }
        }

        public bool Delete(Location location)
        {
            _context.Locations.Remove(location);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return _context.Locations.Any(l => l.LocationId == id);
        }
    }
}
