using LossTracker.Models;
using LossTracker.ViewModel;
using LossTracker.ViewModels;
using System.Threading.Tasks;

namespace LossTracker.Interfaces
{
    public interface ILossRepository
    {
        Task<IEnumerable<Loss>> GetAllAsync();
        Task<Loss> GetByIdAsync(int id);
        Task<IEnumerable<Loss>> FilterLossAsync(LossSearchVM searchParameters);
        Task AddAsync(NewLossVM data);
        Task UpdateAsync(EditLossVM data);
        bool Delete(Loss loss);
        bool Save();
        bool Exists(int id);
    }
}
