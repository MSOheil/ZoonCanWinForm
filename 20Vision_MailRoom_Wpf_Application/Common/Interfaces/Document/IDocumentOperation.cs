namespace _20Vision_MailRoom_Wpf_Application.Common.Interfaces.Document;
public interface IDocumentOperation
{
    Task<T> GetAllDocumentAsync<T>(GetAllDocumentDto dto);
    Task<T> DeleteDocumentAsync<T>(DeleteDocumentDto dto);
    Task<T> UpdateDocumentAsync<T>(UpdateDocumentDto dto);
    Task<T> AddDocumentAsync<T>(CreateDocumentDto dto);
}
