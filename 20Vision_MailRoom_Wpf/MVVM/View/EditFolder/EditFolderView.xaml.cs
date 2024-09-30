namespace _20Vision_MailRoom_Wpf.MVVM.View.EditFolder;
/// <summary>
/// Interaction logic for EditFolderView.xaml
/// </summary>
public partial class EditFolderView : Window
{
    public FolderViewModel FolderViewModel { get; set; }
    private readonly IFolderOperation folderOperation;
    public EditFolderView()
    {
        InitializeComponent();
        folderOperation = new FolderOperation();
    }

    private void AddInitialValue()
    {
        Folder_Name.Text = FolderViewModel.FolderName;
        Zooncan_Code.Text = FolderViewModel.GeneratedCodeForZoonCan.ToString();
        FolderInsertDate.SelectedDate = new PersianDate(Convert.ToDateTime(FolderViewModel.InsertDate));
        Folder_Description.Text = FolderViewModel.FolderDescription;
        Folder_Code.Text = FolderViewModel.GeneratedCodeForFolder.ToString();
    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {

        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
    private async void EditFolder_Btn_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Folder_Name.Text))
        {
            MessageBox.Show("لطفا نام فولدر را وارد کنید");
            return;
        }
        if (string.IsNullOrWhiteSpace(Zooncan_Code.Text))
        {
            MessageBox.Show("لطفا کد زونکن را وارد کنید");
            return;
        }
        if (string.IsNullOrWhiteSpace(Folder_Description.Text))
        {
            MessageBox.Show("لطفا توضیحات فولدر را وارد کنید");
            return;
        }
        try
        {
            var resultOfUpdate = await folderOperation.UpdateFolderAsync<ShowFolderDto>(new UpdateFolderDto
            {
                FolderDescription = Folder_Description.Text,
                FolderId = FolderViewModel.FolderId,
                FolderName = Folder_Name.Text,
                GeneratedCodeForFolder = int.Parse(Folder_Code.Text),
                InsertDate = FolderInsertDate.SelectedDate.ToString(),
                ZoonCanId = FolderViewModel.ZoonCanId,
                ZoonCanGeneratedCode = int.Parse(Zooncan_Code.Text)
            });
            MessageBox.Show("ویرایش با موفقیت انجام شد");
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("کد فولدر تکراری است");
            Close();
            return;
        }
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        AddInitialValue();
    }
}
