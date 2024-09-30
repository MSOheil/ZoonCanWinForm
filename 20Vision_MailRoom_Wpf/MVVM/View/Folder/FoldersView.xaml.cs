namespace _20Vision_MailRoom_Wpf.MVVM.View.Folder;
/// <summary>
/// Interaction logic for FoldersView.xaml
/// </summary>
public partial class FoldersView : Window
{
    private readonly IFolderOperation folderOperation;
    public ShowFolderByZoonCanDto ShowFolderByZoonCanDto { get; set; }
    public FoldersView()
    {
        InitializeComponent();
        folderOperation = new FolderOperation();
    }
    private async Task RefreshDataGridAsync()
    {
        var folders = await folderOperation.GetAllFolderAsync<PaginatedList<ShowFolderDto>>(new GetAllFolderDto
        {
            PageNumber = 1,
            PageSize =20,
            ZoonCanId = ShowFolderByZoonCanDto.ZoonCanId
        });
        var folderViewModel = new ObservableCollection<FolderViewModel>();
        foreach (var folder in folders.Items)
        {
            folderViewModel.Add(new FolderViewModel
            {
                FolderDescription = folder.FolderDescription,
                FolderId = folder.FolderId,
                FolderName = folder.FolderName,
                GeneratedCodeForFolder = folder.GeneratedCodeForFolder,
                InsertDate = folder.InsertDate,
                ZoonCanId = folder.ZoonCanId,
                GeneratedCodeForZoonCan= ShowFolderByZoonCanDto.GeneratedCodeForZoonCan,
            });
        }
        FDG_View.ItemsSource = folderViewModel;
    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        var zoonCanView = new ZoonCanView();
        Close();
        zoonCanView.ShowDialog();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private async void AddFolder_Click(object sender, RoutedEventArgs e)
    {
        var addFolder = new AddFolderView();
        addFolder.ShowFolderByZoonCanDto = new ShowFolderByZoonCanDto
        {
            ZoonCanId = ShowFolderByZoonCanDto.ZoonCanId,
            GeneratedCodeForZoonCan = ShowFolderByZoonCanDto.GeneratedCodeForZoonCan
        };
        addFolder.ShowDialog();
        await RefreshDataGridAsync();
    }

    private async void EditFolder_Click(object sender, RoutedEventArgs e)
    {
        var editFolderView = new EditFolderView();
        var folder = (FolderViewModel)FDG_View.SelectedItem;
        if (folder is not null)
        {
            editFolderView.FolderViewModel = folder;
            editFolderView.FolderViewModel.GeneratedCodeForZoonCan = ShowFolderByZoonCanDto.GeneratedCodeForZoonCan;
            editFolderView.ShowDialog();
            await RefreshDataGridAsync();
            return;
        }

        MessageBox.Show("لطفا سطری را برای ویرایش انتخاب کنید");
    }

    private async void DeleteFolder_Click(object sender, RoutedEventArgs e)
    {
        var folder = (FolderViewModel)FDG_View.SelectedItem;
        if (folder is not null)
        {
            try
            {
                var resultOfDelete = await folderOperation.DeleteFolderAsync<bool>(new DeleteFolderDto
                {
                    FolderId = folder.FolderId
                });
                if (resultOfDelete)
                {
                    MessageBox.Show("فولدر  با موفقیت حذف شد");
                    await RefreshDataGridAsync();
                    return;
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ابتدا سند های فولدر را به زونکن دیگر انتقال دهید یا حذف کنید");
                return;
            }
        }
        MessageBox.Show("لطفا برای حذف سطری را انتخاب کن");
    }

    private async void FolderLoaded(object sender, RoutedEventArgs e)
    {
        if (!Guid.Empty.Equals(ShowFolderByZoonCanDto.ZoonCanId))
        {
            await RefreshDataGridAsync();
        }

    }

    private void ShowDocument_Btn_Click(object sender, RoutedEventArgs e)
    {
        var folder = (FolderViewModel)FDG_View.SelectedItem;
        if (folder is not null)
        {
            var documentView = new DocumentView();
            documentView.FolderViewModel = folder;
            Close();
            documentView.ShowDialog();
            return;
        }
        MessageBox.Show("لطفا سطری را برای نمایش سند انتخاب کنید");
    }
}
