using LossTracker.Models;
using System.Threading.Tasks;

namespace LossTracker.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location> GetByIdAsync(int id);
        Task AddAsync(Location location);
        Task UpdateAsync(Location location);
        bool Delete(Location location);
        bool Save();
        bool Exists(int id);
    }
}
