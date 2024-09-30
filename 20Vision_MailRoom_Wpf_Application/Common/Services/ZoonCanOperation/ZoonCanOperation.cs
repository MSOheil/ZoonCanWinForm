namespace _20Vision_MailRoom_Wpf_Application.Common.Services.ZoonCanOperation;
public class ZoonCanOperation : IZoonCanOperation
{
    private readonly IRestSharpOperation restSharpOperation;
    private readonly IFileOperation fileOperation;
    public ZoonCanOperation()
    {
        fileOperation = new _20Vision_MailRoom_Wpf_Application.Common.Services.FileOperation.FileOperation();
        var ipAddress = fileOperation.ReadIpAddressFromTextFile();
        restSharpOperation = new RestSharpOperation(ipAddress);

    }
    public async Task AddZoonCanOperationAsync(string zoonCanName, string colorName, string zoonCanDescription, string insertedZoonCanDate)
    {
        var zoonCan = new CreateZoonCanDto()
        {
            GeneratedCodeForZoonCan = 0,
            ZoonCanColor = colorName,
            ZoonCanDescription = zoonCanDescription,
            ZoonCanName = zoonCanName,
            InsertZoonCanDateTime = insertedZoonCanDate
        };
        await restSharpOperation.PostAsync<ShowZoonCanDto>("/api/ZoonCan/CreateZoonCan", zoonCan);
    }

    public async Task<bool> DelteZoonCanAsync(Guid zoonCanId)
    {
        var deleteZoonCanDto = new DeleteZoonCanDto()
        {
            ZoonCanId = zoonCanId
        };
        return await restSharpOperation.DeleteAsync<bool>("/api/ZoonCan/DeleteZoonCan", deleteZoonCanDto);
    }

    public async Task<T> GetAllZoonCanAsync<T>(GetAllZoonCanQuery dto)
    => await restSharpOperation.GetAsync<T>("/api/ZoonCan/GetAllZoonCan", dto);

    public async Task<T> UpdateZoonCanAsync<T>(UpdateZoonCanDto updateZoonCanDto)
     => await restSharpOperation.UpdateAsync<T>("/api/ZoonCan/UpdateZoonCanAsync", updateZoonCanDto);
}
