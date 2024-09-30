namespace _20Vision_MailRoom_Wpf_Application.Common.Services.FileOperation;

public class FileOperation : IFileOperation
{
    public void CreateDirectory(string filePath)
    {
        if (!this.IsExistFile(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
    }

    public async Task CreateFileAsync(string filePath, byte[] fileSize, string folderPath)
    {
        CreateDirectory(folderPath);
        using (FileStream fs = File.Create(filePath))
        {
            await fs.WriteAsync(fileSize, 0, fileSize.Length);
            fs.Dispose();
        }
    }

    public async Task DeleteAllFilesAsync(string filePath)
    {
        try
        {
            string[] filePaths = Directory.GetFiles(filePath);
            foreach (string fp in filePaths)
                File.Delete(fp);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {

        }
    }

    public string GetFileAddres(string fileName, string folderName)
     => Directory.GetCurrentDirectory() + $"\\{folderName}\\{fileName}";

    public bool IsExistFile(string filePath)
    {
        return File.Exists(filePath);
    }

    public string ReadIpAddressFromTextFile()
    {
        var filePat = GetFileAddres("ServerIp.txt", "IpAddress");
        return  File.ReadAllText(filePat);
    }
}
