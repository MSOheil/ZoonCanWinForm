namespace _20Vision_MailRoom_Wpf.MVVM.View.AddFolder;
/// <summary>
/// Interaction logic for AddFolderView.xaml
/// </summary>
public partial class AddFolderView : Window
{
    private readonly IFolderOperation folderOperation;
    public ShowFolderByZoonCanDto ShowFolderByZoonCanDto { get; set; }
    public AddFolderView()
    {
        folderOperation = new FolderOperation();
        InitializeComponent();
    }

    private async void AddFolder_Btn_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Folder_Name.Text))
        {
            MessageBox.Show("لطفا نام فولدر را وارد کنید");
            return;
        }
        if (string.IsNullOrWhiteSpace(Folder_Description.Text))
        {
            MessageBox.Show("لطفا توضیحات فولدر را وارد کنید");
            return;
        }
        var folderInsertDate = FolderInsertDate.SelectedDate.ToString();
        try
        {
            await folderOperation.CreateFolderAsync<ShowFolderDto>(new CreateFolderDto
            {
                FolderDescription = Folder_Description.Text,
                FolderName = Folder_Name.Text,
                InsertDate = folderInsertDate,
                ZoonCanId = ShowFolderByZoonCanDto.ZoonCanId
            });
            MessageBox.Show("فولدر با موفقیت ثبت شد");
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("عملیات ثبت موفقیت امیز نبود");
            Close();
            return;
        }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }
}
