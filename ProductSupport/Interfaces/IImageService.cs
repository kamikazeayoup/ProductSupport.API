namespace ProductSupport.API.Interfaces
{
    public interface IImageService
    {
         void DeleteImage(string? filePath);
        bool IsFileValidImage(string Base64Image, byte[] imageBytes);

        string SaveImage(string base64String, string Code , string fileaddress);
        string DetectImageType(string base64Image);
    }
}
