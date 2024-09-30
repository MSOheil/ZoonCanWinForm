namespace _20Vision_MailRoom_Wpf_Application.Common.Interfaces.FileOperation;

public interface IFileOperation
{
    Task CreateFileAsync(string filePath, byte[] fileSize, string folderPath);
    bool IsExistFile(string filePath);
    Task DeleteAllFilesAsync(string folderPath);
    void CreateDirectory(string filePath);
    string ReadIpAddressFromTextFile();
    string GetFileAddres(string fileName, string folderName);
}
