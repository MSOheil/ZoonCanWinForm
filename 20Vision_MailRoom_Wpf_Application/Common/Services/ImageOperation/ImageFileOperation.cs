namespace _20Vision_MailRoom_Wpf_Application.Common.Services.ImageOperation;
public class ImageFileOperation : IImageFileOperation
{
    private readonly IFileOperation fileOperation;
    private readonly IRestSharpOperation restSharpOperation;

    public ImageFileOperation()
    {
        fileOperation = new _20Vision_MailRoom_Wpf_Application.Common.Services.FileOperation.FileOperation();
        var ipAddress = fileOperation.ReadIpAddressFromTextFile();
        restSharpOperation = new RestSharpOperation(ipAddress);
    }

    public async Task<T> CreateImageAsync<T>(byte[] fileBytes, string imageDescription, Guid documentId, string fileName, string actionUrl)
     => await restSharpOperation.PostFileAsync<T>(fileBytes, imageDescription, documentId, fileName, actionUrl);

    public async Task<T> DeleteImageByImageInformationIdAsync<T>(DeleteImageInformationDto dto)
    => await restSharpOperation.DeleteAsync<T>("api/Image/DeleteImageInformation", dto);

    public async Task<T> GetImagebyDocumentIdAsync<T>(GetImageInformationByDocumentIdDto dto)
    => await restSharpOperation.GetByIdAsync<T>("/api/Image/GetImageById", dto);
}
