using CloudinaryDotNet.Actions;

namespace RunDietSystem.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        
        Task<DeletionResult> DeletePhotoAsync(string publicId);

    }
}
