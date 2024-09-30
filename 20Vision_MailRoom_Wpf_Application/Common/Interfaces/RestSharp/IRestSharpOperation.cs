namespace _20Vision_MailRoom_Wpf_Application.Common.Interfaces.RestSharp;
public interface IRestSharpOperation
{
    RestClient ConnectToServerAsync(string serverUrl);
    Task<TResult> GetAsync<TResult>(string actionUrl, object? requestQuery);
    Task<TResult> GetByIdAsync<TResult>(string actionUrl, object? requestQuery);
    Task<TResult> PostAsync<TResult>(string actionUrl, object? requestBody);
    Task<TResult> DeleteAsync<TResult>(string actionUrl, object requestBody);
    Task<TResult> UpdateAsync<TResult>(string actionUrl, object requestBody);
    Task<TResult> PostFileAsync<TResult>(byte[] fileBytes, string imageDescription, Guid DocumentId, string fileName, string actionUrl);
}
