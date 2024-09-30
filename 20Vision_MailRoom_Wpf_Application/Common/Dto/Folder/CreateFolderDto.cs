namespace _20Vision_MailRoom_Wpf_Application.Common.Dto.Folder;

public class CreateFolderDto
{
    public string? FolderName { get; set; }
    public string? InsertDate { get; set; }
    public string? FolderDescription { get; set; }
    public int GeneratedCodeForFolder { get; set; }
    public Guid ZoonCanId { get; set; }
}
