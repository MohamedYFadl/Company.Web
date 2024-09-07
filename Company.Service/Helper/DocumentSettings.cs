using Microsoft.AspNetCore.Http;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file,string folderName) 
        {
            //1. Get Folder Path
            //var folderPath = @"T:\\Mohamed\\Back-end\\Route\\Videos\\Ahmed Khaled\\MVC\\MVC03\\Company.Web\\wwwroot\\Files\\Images\\"; //StaticFile, هتعمل مشاكل علي السيرفر

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName); // it will combine the inputs to make folder path

            //2. Get File Name اللي هرفعه
            //var fileName = file.FileName; // هتعمل مشاكل لواعتمدت علي دا بس زي ان واحد يرفع ملفين بنفس الأسم الحل اننا نخليه Unique
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";

            //3. Combine FolderPath + FilePath
            var filePath = Path.Combine(folderPath, fileName);

            //4. Save File
            using var fileStream = new FileStream(filePath,FileMode.Create);

            file.CopyTo(fileStream);

            return filePath;
        }
    }
}
