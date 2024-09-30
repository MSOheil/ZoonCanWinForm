namespace _20Vision_MailRoom_Wpf_Application.Common.Services.FolderOperation;
public class FolderOperation : IFolderOperation
{
    private readonly IFileOperation fileOperation;
    private readonly IRestSharpOperation restSharpOperation;

    public FolderOperation()
    {
        fileOperation = new _20Vision_MailRoom_Wpf_Application.Common.Services.FileOperation.FileOperation();
        var ipAddress = fileOperation.ReadIpAddressFromTextFile();
        restSharpOperation = new RestSharpOperation(ipAddress);
    }

    public async Task<T> CreateFolderAsync<T>(CreateFolderDto dto)
    => await restSharpOperation.PostAsync<T>("/api/Folder/CreateFolder", dto);

    public async Task<T> DeleteFolderAsync<T>(DeleteFolderDto dto)
    => await restSharpOperation.DeleteAsync<T>("/api/Folder/DeleteFolder", dto);

    public async Task<T> GetAllFolderAsync<T>(GetAllFolderDto folder)
    => await restSharpOperation.GetAsync<T>("/api/Folder/GetAllFolders", folder);

    public async Task<T> UpdateFolderAsync<T>(UpdateFolderDto dto)
    => await restSharpOperation.UpdateAsync<T>("/api/Folder/UpdateFolder", dto);
}
