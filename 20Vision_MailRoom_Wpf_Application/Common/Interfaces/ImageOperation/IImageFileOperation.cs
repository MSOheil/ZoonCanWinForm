namespace _20Vision_MailRoom_Wpf_Application.Common.Interfaces.ImageOperation;

public interface IImageFileOperation
{
    Task<T> CreateImageAsync<T>(byte[] fileBytes, string imageDescription, Guid documentId, string fileName, string actionUrl);
    Task<T> GetImagebyDocumentIdAsync<T>(GetImageInformationByDocumentIdDto dto);
    Task<T> DeleteImageByImageInformationIdAsync<T>(DeleteImageInformationDto dto);
}
