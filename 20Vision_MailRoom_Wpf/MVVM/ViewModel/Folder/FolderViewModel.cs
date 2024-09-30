namespace _20Vision_MailRoom_Wpf.MVVM.ViewModel.Folder;

public class FolderViewModel
{
    public Guid FolderId { get; set; }
    public string? FolderName { get; set; }
    public string? InsertDate { get; set; }
    public string? FolderDescription { get; set; }
    public Guid ZoonCanId { get; set; }
    public int GeneratedCodeForFolder { get; set; }
    public int? GeneratedCodeForZoonCan { get; set; }
}
