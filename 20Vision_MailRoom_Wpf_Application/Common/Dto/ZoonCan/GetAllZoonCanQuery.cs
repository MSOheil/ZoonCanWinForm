namespace _20Vision_MailRoom_Wpf_Application.Common.Dto.ZoonCanQuery;

public class GetAllZoonCanQuery
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? ZoonCanName { get; set; }
    public string? ZoonCanDescription { get; set; }
    public string? ZoonCanColor { get; set; }
    public string? ZoonCanGeneratedCode { get; set; }
}
