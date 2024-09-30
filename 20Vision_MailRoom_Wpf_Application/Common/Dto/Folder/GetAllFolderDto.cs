namespace _20Vision_MailRoom_Wpf_Application.Common.Dto.Folder;

public class GetAllFolderDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? FolderName { get; set; }
    public string? InsertDate { get; set; }
    public string? FolderDescription { get; set; }
    public int GeneratedCodeForFolder { get; set; }
    public Guid ZoonCanId { get; set; }
}
