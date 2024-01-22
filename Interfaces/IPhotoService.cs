using CloudinaryDotNet.Actions;

namespace TheatreBookingSystem_MVC.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicUrl);
    }
}
