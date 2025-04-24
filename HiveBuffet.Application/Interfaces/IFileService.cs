using Microsoft.AspNetCore.Http;

namespace HiveBuffet.Application.Interfaces;

public interface IFileService
{
    Task<string> UploadImageAsync(IFormFile file);

    void DeleteImage(string fileName);
}