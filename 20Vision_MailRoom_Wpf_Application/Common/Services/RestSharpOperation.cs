namespace _20Vision_MailRoom_Wpf_Application.Common.Services;
public class RestSharpOperation : IRestSharpOperation
{
    private RestRequest restRequest;
    private RestClient restClient;
    private readonly string serverUrl;
    public RestSharpOperation(string serverUrl)
    {
        this.serverUrl = serverUrl;
        restRequest = new RestRequest();
    }
    public RestClient ConnectToServerAsync(string serverUrl)
     => new RestClient(new RestClientOptions(serverUrl)
     {
         ThrowOnAnyError = true,
     });

    public async Task<TResult> GetAsync<TResult>(string actionUrl, object? requestQuery)
    {
        restClient = ConnectToServerAsync(serverUrl);
        restRequest = new RestRequest(actionUrl, Method.Get);
        if (requestQuery != null)
            restRequest.AddObject(requestQuery);
        var response = await restClient.ExecuteAsync(restRequest);
        return JsonConvert.DeserializeObject<TResult>(response.Content);
    }
    public async Task<TResult> PostAsync<TResult>(string actionUrl, object? requestBody)
    {
        restClient = ConnectToServerAsync(serverUrl);
        restRequest = new RestRequest(actionUrl, Method.Post);
        if (requestBody != null)
            restRequest.AddBody(requestBody);

        var response = await restClient.ExecuteAsync<TResult>(restRequest);
        return JsonConvert.DeserializeObject<TResult>(response.Content);
    }

    public async Task<TResult> DeleteAsync<TResult>(string actionUrl, object requestBody)
    {
        restClient = ConnectToServerAsync(serverUrl);
        restRequest = new RestRequest(actionUrl, Method.Delete);

        if (requestBody != null)
            restRequest.AddBody(requestBody);
        var response = await restClient.ExecuteAsync<TResult>(restRequest);
        return JsonConvert.DeserializeObject<TResult>(response.Content);
    }

    public async Task<TResult> UpdateAsync<TResult>(string actionUrl, object requestBody)
    {
        restClient = ConnectToServerAsync(serverUrl);
        restRequest = new RestRequest(actionUrl, Method.Put);
        if (requestBody != null)
            restRequest.AddBody(requestBody);
        var response = await restClient.ExecuteAsync<TResult>(restRequest);
        return JsonConvert.DeserializeObject<TResult>(response.Content);
    }

    public async Task<TResult> PostFileAsync<TResult>(byte[] fileBytes, string imageDescription, Guid DocumentId, string fileName, string actionUrl)
    {
        restClient = ConnectToServerAsync(serverUrl);
        restRequest = new RestRequest(actionUrl, Method.Post);
        restRequest.AddFile("file", fileBytes, fileName);
        restRequest.AddQueryParameter("imageDescription", imageDescription);
        restRequest.AddQueryParameter("DocumentId", DocumentId);
        var response = await restClient.ExecuteAsync<TResult>(restRequest);
        return JsonConvert.DeserializeObject<TResult>(response.Content);
    }

    public async Task<TResult> GetByIdAsync<TResult>(string actionUrl, object? requestQuery)
    {
        restClient = ConnectToServerAsync(serverUrl);
        restRequest = new RestRequest(actionUrl, Method.Get);
        if (requestQuery != null)
            restRequest.AddObject(requestQuery);
        var response = await restClient.ExecuteAsync<TResult>(restRequest);
        return JsonConvert.DeserializeObject<TResult>(response.Content);
    }
}

