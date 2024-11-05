namespace project1.Services
{
    public interface IRescaleImageService
    {
        Task  ResizeImageFromUrlAsync(string imageUrl, string outputDirectory);
    }
}
