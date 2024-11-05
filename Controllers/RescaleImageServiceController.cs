using Microsoft.AspNetCore.Mvc;
using project1.Models;
using project1.Services;
using SixLabors.ImageSharp.Formats;

namespace project1.Controllers
{
    public class RescaleImageServiceController : ControllerBase
    {
        private readonly IRescaleImageService _rescaleImageService;
        public RescaleImageServiceController(IRescaleImageService rescaleImageService)
        {
            _rescaleImageService = rescaleImageService;
        }

        [HttpPost("image-resize")]
        public async Task<IActionResult> GetEmployeeCSV(ImageResizeRequest request)
        {
            
           // var imageUrl = "https://example.com/image.jpg"; // Replace with your image URL
           // var outputDirectory = @"C:\Images"; // Replace with your desired output directory

            //var resizer = new ImageResizer();
            var resizedImage =   _rescaleImageService.ResizeImageFromUrlAsync(request.ImageUrl, request.OutputDirectory);

            Console.WriteLine("Images resized and saved.");
            return Ok();
        }
    }
}




