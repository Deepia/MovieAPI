namespace MovieAPI.Helpers
{
    public interface IFileStorageService
    {
        Task DeleteFile(string fileRoute, string containerName);
        Task<string> SaveFile(string continerName, IFormFile file);
        Task<string> EditFile(string continerName, IFormFile file,string fileRoute);
    }
}
