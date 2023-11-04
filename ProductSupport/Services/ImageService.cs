using ProductSupport.API.Interfaces;

namespace ProductSupport.API.Services
{
    public class ImageService : IImageService
    {
        public string SaveImage(string base64String, string Code, string fileaddress)
        {
            // Decode base64 string to byte array

            byte[] imageBytes = Convert.FromBase64String(base64String);

            if (IsFileValidImage(base64String, imageBytes))
            {
                // Generate a unique filename (you may want to use a library for this)
                string filename = fileaddress + "_" + Code + "." + DetectImageType(base64String);
                string folderPath = Path.Combine("Images", fileaddress);
                // Define the path to save the image
                string filePath = Path.Combine(folderPath, filename);
                // Save the image to the server
                System.IO.File.WriteAllBytes(filePath, imageBytes);
                return filePath;
            }
            return "null";
        }
        public void DeleteImage(string? filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        public bool IsFileValidImage(string Base64Image, byte[] imageBytes)
        {
            if (DetectImageType(Base64Image) == null)
                return false;



            if (imageBytes.Length > 5 * 1024 * 1024)
            {
                return false;
            }
            return true;

        }

        public string DetectImageType(string base64Image)
        {
            byte[] imageBytes = Convert.FromBase64String(base64Image.Substring(0, 16));

            if (imageBytes.Length >= 2 && imageBytes[0] == 0xFF && imageBytes[1] == 0xD8)
            {
                return "jpg";
            }
            else if (imageBytes.Length >= 8 &&
                     imageBytes[1] == 0x50 && imageBytes[2] == 0x4E && imageBytes[3] == 0x47)
            {
                return "png";
            }

            return null;
        }

        enum ImageType
        {
            JPEG,
            PNG
        }
    }
}
