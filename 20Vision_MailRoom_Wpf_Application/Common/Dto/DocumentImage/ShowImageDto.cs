namespace _20Vision_MailRoom_Wpf_Application.Common.Dto.DocumentImage;

public class ShowImageDto
{
    public string? ImagePath { get; set; }
    public string? ImageDescription { get; set; }
    public string? ImageName { get; set; }
    public string? ImageSuffix { get; set; }
    public byte[]? ImageFile { get; set; }
    public Guid ImageInformationId { get; set; }
}
