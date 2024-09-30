namespace _20Vision_MailRoom_Wpf_Application.Common.Dto.Document;

public class GetAllDocumentDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? DocumentName { get; set; }
    public string? InsertDocumentDate { get; set; }
    public string? DocumentDescription { get; set; }
    public int GeneratedCodeForDocument { get; set; }
    public Guid FolderId { get; set; }
}
