namespace _20Vision_MailRoom_Wpf.MVVM.ViewModel.Document;

public class ShowDocumentViewModel
{
    public string? DocumentName { get; set; }
    public string? InsertDocumentDate { get; set; }
    public string? DocumentDescription { get; set; }
    public Guid FolderId { get; set; }
    public int GeneratedCodeForDocument { get; set; }
    public Guid DocumentId { get; set; }
    public Guid ZoonCanId { get; set; }
}
