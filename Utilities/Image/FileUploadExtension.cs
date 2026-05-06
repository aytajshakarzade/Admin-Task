using Admin_Task.Models;

namespace Admin_Task.Utilities.Image
{
    public static class FileUploadExtension
    {
        public static string SaveImage(this IFormFile file, IWebHostEnvironment env, string folderName)
        {
            string path = Path.Combine(env.WebRootPath, "uploads", folderName);
            string fileName = Guid.NewGuid() + file.FileName;
            string fullPath = Path.Combine(path, fileName);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }
    }
}
