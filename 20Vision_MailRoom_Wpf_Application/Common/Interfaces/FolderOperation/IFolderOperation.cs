namespace _20Vision_MailRoom_Wpf_Application.Common.Interfaces.FolderOperation;
public interface IFolderOperation
{
    Task<T> GetAllFolderAsync<T>(GetAllFolderDto folder);
    Task<T> CreateFolderAsync<T>(CreateFolderDto dto);
    Task<T> DeleteFolderAsync<T>(DeleteFolderDto dto);
    Task<T> UpdateFolderAsync<T>(UpdateFolderDto dto);
}
