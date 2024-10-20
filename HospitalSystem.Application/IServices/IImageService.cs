namespace HospitalSystem.Application.IServices
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(IFormFile Img, string folderPath);
        Task DeleteFileAsync(string File);
    }
}
