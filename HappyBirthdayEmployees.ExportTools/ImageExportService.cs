using HappyBirthdayEmployees.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace HappyBirthdayEmployees.ExportTools;

public static class ImageExportService
{
    public static async Task ImportSingleFile(string dirPath, IFormFile file, JobPosition? jobPosition = null)
    {
        if (file.Length > 0 && (file.FileName.EndsWith(".jpg")))
        {
            var dirPathInfo = new DirectoryInfo(dirPath);
            if (!dirPathInfo.Exists) dirPathInfo.Create();
            var fullPath = Path.Combine(dirPathInfo.FullName, jobPosition.ToString() + "." + file.FileName.Split('.').Last());
            await using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }

    public static string? ExportFullPathImage(string dirPath, JobPosition jobPosition)
    {
        var dirInfo = new DirectoryInfo(dirPath);
        return Directory.GetFiles(dirInfo.FullName)
            .FirstOrDefault(file => 
            file.Contains(jobPosition.ToString() + ".jpg"));
    }
}