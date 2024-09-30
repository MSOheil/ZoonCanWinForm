namespace _20Vision_MailRoom_Wpf_Application.Common.Interfaces.ZoonCanOperation;

public interface IZoonCanOperation
{
    Task AddZoonCanOperationAsync(string zoonCanName, string colorName, string zoonCanDescription, string insertedZoonCanDate);
    Task<bool> DelteZoonCanAsync(Guid zoonCanId);
    Task<T> UpdateZoonCanAsync<T>(UpdateZoonCanDto updateZoonCanDto);
    Task<T> GetAllZoonCanAsync<T>(GetAllZoonCanQuery dto);
}
