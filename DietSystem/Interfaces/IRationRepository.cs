using DietSystem.Models;
using DietSystem.ViewModels;
using RunDietSystem.Data.Enum;
using RunDietSystem.ViewModels;

namespace DietSystem.Interfaces
{
    public interface IRationRepository
    {
        Task<IEnumerable<Ration>> GetAll();
        Task<Ration> GetByUserIdAsync();
        Task Add(Ration ration);
        Task Update(Ration ration);
        bool Delete(Ration ration);
        bool Save();
        bool Exists(int id);
    }
}
