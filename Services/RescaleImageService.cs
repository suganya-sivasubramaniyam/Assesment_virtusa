using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;

namespace project1.Services
{
    public class RescaleImageService : IRescaleImageService
    {
        private readonly HttpClient _httpClient;

        public RescaleImageService() {
            _httpClient = new HttpClient();
        }


        public async Task ResizeImageFromUrlAsync(string imageUrl, string outputDirectory)
        {
            try
            {
                // Download the image
                var imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);

                using (var image = Image.Load(imageBytes))
                {
                    // Resize to thumbnail (100x80)
                    var thumbnail = image.Clone(ctx => ctx.Resize(100, 80));
                    thumbnail.Save(Path.Combine(outputDirectory, "thumbnail.jpg")); // You can change the format if needed
                    thumbnail.Dispose();

                    // Resize to preview (1200x1600)
                    var preview = image.Clone(ctx => ctx.Resize(1200, 1600));
                    preview.Save(Path.Combine(outputDirectory, "preview.jpg")); // You can change the format if needed
                    preview.Dispose();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}






    //////////////////////////////////////////////////////////////////////////////////////////////////////
    /// 
    //public async Task ResizeImageFromUrlAsync(string imageUrl, string outputDirectory)
    //{
    //    try
    //    {
    //        // Download the image
    //        var imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);

    //        using (var ms = new MemoryStream(imageBytes))
    //        {
    //            using (var originalImage = Image.FromStream(ms))
    //            {
    //                // Resize to thumbnail (100x80)
    //                var thumbnail = ResizeImage(originalImage, 100, 80);
    //                thumbnail.Save(Path.Combine(outputDirectory, "thumbnail.jpg"), ImageFormat.Jpeg);
    //                thumbnail.Dispose();

    //                // Resize to preview (1200x1600)
    //                var preview = ResizeImage(originalImage, 1200, 1600);
    //                preview.Save(Path.Combine(outputDirectory, "preview.jpg"), ImageFormat.Jpeg);
    //                preview.Dispose();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"An error occurred: {ex.Message}");
    //    }
    //}

    //private Image ResizeImage(Image image, int width, int height)
    //{
    //    var resizedImage = new Bitmap(width, height);
    //    using (var graphics = Graphics.FromImage(resizedImage))
    //    {
    //        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    //        graphics.DrawImage(image, 0, 0, width, height);
    //    }
    //    return resizedImage;
    //}






