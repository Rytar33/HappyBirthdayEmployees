using HappyBirthdayEmployees.ExportTools;
using HappyBirthdayEmployees.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HappyBirthdayEmployees.WebApi.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class ImageController : Controller
{
    private readonly string _dirPath = "wwwroot/images/for-congratulations";
    [HttpPost]
    public async Task<IActionResult> AddNewImage([FromForm] CreateNewImageForSendRequest createNewImageForSendRequest)
    {
        await ImageExportService.ImportSingleFile(
            _dirPath,
            createNewImageForSendRequest.FormFile,
            createNewImageForSendRequest.JobPosition);
        return Created(
            ImageExportService.ExportFullPathImage(
                _dirPath,
                createNewImageForSendRequest.JobPosition),
            createNewImageForSendRequest.FormFile);
    }
}

public record CreateNewImageForSendRequest(IFormFile FormFile, JobPosition JobPosition);