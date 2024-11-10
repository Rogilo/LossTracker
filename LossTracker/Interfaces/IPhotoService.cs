using CloudinaryDotNet.Actions;

namespace LossTracker.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        
        Task<DeletionResult> DeletePhotoAsync(string publicId);

    }
}
