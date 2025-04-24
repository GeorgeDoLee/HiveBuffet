using HiveBuffet.Application.Interfaces;
using Microsoft.AspNetCore.Http;
namespace HiveBuffet.Application.Services;

internal class FileService : IFileService
{
    private readonly string _uploadsDirectory;

    public FileService(string uploadsDirectory)
    {
        _uploadsDirectory = uploadsDirectory;

        if (!Directory.Exists(_uploadsDirectory))
        {
            Directory.CreateDirectory(_uploadsDirectory);
        }
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("No file provided.");
        }

        var fileName = Guid.NewGuid().ToString() + $"_{file.FileName}";
        var filePath = Path.Combine(_uploadsDirectory, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"uploads/{fileName}";
    }

    public void DeleteImage(string fileName)
    {
        var filePath = Path.Combine(_uploadsDirectory, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
