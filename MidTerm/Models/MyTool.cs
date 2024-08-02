namespace MidTerm.Models
{
    public class MyTool
    {
        public static string UploadImageToFolder(IFormFile myfile, string folder)
        {

            if (myfile == null)
            {
                return string.Empty;
            }
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HinhAnh","SanPham", folder, myfile.FileName);
                using (var newFile = new FileStream(fullPath, FileMode.CreateNew))
                {
                    myfile.CopyTo(newFile);
                }
                return myfile.FileName;
            }
            catch (Exception ex) { return string.Empty; }
        }
    }
}
