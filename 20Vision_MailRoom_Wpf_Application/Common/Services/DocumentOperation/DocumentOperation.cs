namespace _20Vision_MailRoom_Wpf_Application.Common.Services.DocumentOperation;
public class DocumentOperation : IDocumentOperation
{
    private readonly IRestSharpOperation restSharpOperation;
    private readonly IFileOperation fileOperation;
    public DocumentOperation()
    {
        fileOperation = new _20Vision_MailRoom_Wpf_Application.Common.Services.FileOperation.FileOperation();
        var ipAddress = fileOperation.ReadIpAddressFromTextFile();
        restSharpOperation = new RestSharpOperation(ipAddress);
    }

    public async Task<T> AddDocumentAsync<T>(CreateDocumentDto dto)
   => await restSharpOperation.PostAsync<T>("/api/Document/CreateDocument", dto);

    public async Task<T> DeleteDocumentAsync<T>(DeleteDocumentDto dto)
    => await restSharpOperation.DeleteAsync<T>("/api/Document/DeleteDocument", dto);

    public async Task<T> GetAllDocumentAsync<T>(GetAllDocumentDto dto)
      => await restSharpOperation.GetAsync<T>("/api/Document/GetallDocument", dto);

    public async Task<T> UpdateDocumentAsync<T>(UpdateDocumentDto dto)
   => await restSharpOperation.UpdateAsync<T>("/api/Document/UpdateDocument", dto);
}
