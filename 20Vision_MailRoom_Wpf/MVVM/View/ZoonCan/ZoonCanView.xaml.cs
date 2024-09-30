namespace _20Vision_MailRoom_Wpf.MVVM.View.ZoonCan;
/// <summary>
/// Interaction logic for ZoonCanView.xaml
/// </summary>
public partial class ZoonCanView : Window
{
    private readonly IZoonCanOperation zoonCanOperation;
    private readonly IFileOperation fileOperation;
    public ZoonCanView()
    {
        InitializeComponent();
        fileOperation = new FileOperation();
        zoonCanOperation = new ZoonCanOperation();
    }
    private async Task RefreshDataGridViewAsync()
    {
        try
        {
            var zoonCans = await zoonCanOperation.GetAllZoonCanAsync<PaginatedList<ShowZoonCanDto>>(new GetAllZoonCanQuery
            {
                PageNumber = 1,
                PageSize = 10,
            });
            var converter = new BrushConverter();
            var zoonCanViewModels = new ObservableCollection<ZoonCanViewModel>();

            foreach (var zoonCan in zoonCans.Items)
            {
                zoonCanViewModels.Add(new ZoonCanViewModel
                {
                    ZoonCanColor = (Brush)converter.ConvertFromString(zoonCan.ZoonCanColor),
                    ZoonCanDescription = zoonCan.ZoonCanDescription,
                    ZoonCanGeneratedCode = zoonCan.ZoonCanGeneratedCode,
                    ZoonCanName = zoonCan.ZoonCanName,
                    ZoonCanId = zoonCan.ZoonCanId,
                    ZoonCanInsertDate = zoonCan.zoonCanInsertDate
                });
            }
            ZDG_View.ItemsSource = zoonCanViewModels;
            AddBtn.Visibility = Visibility.Visible;
            EditBtn.Visibility = Visibility.Visible;
            DeleteBtn.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            MessageBox.Show("شما نمیتوانید به سرور وصل شوید لطفا اتصال اینترنت را بررسی کنید");
            var mainView = new MainView();
            await fileOperation.DeleteAllFilesAsync(Directory.GetCurrentDirectory() + $"\\Images");
            Close();
            mainView.ShowDialog();
        }
    }
    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }
    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        var mainView = new MainView();
        fileOperation.DeleteAllFilesAsync(Directory.GetCurrentDirectory() + $"\\Images");
        Close();
        mainView.ShowDialog();
    }
    private bool IsMaximized = false;
    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount.Equals(2))
        {
            if (IsMaximized)
            {
                WindowState = WindowState.Normal;
                Width = 1080;
                Height = 720;
                IsMaximized = false;
            }
            else
            {
                WindowState = WindowState.Maximized;
                IsMaximized = true;
            }
        }
    }

    private void AddZoonCan_Click(object sender, RoutedEventArgs e)
    {
        var addOrEditView = new AddOrEditView();
        Close();
        addOrEditView.ShowDialog();
    }

    private void EditZoonCan_Click(object sender, RoutedEventArgs e)
    {
        var zoonCanViewModel = (ZoonCanViewModel)ZDG_View.SelectedItem;
        if (zoonCanViewModel is null)
        {
            MessageBox.Show("لطفا یک سطرح را انتخاب کنید");
            return;
        }
        var editView = new EditZoonCanView();
        editView.ZoonCanViewModel = zoonCanViewModel;
        Close();
        editView.ShowDialog();
    }

    private async void DeleteZoonCan_Click(object sender, RoutedEventArgs e)
    {
        var zoonCanViewModel = (ZoonCanViewModel)ZDG_View.SelectedItem;
        if (zoonCanViewModel is not null)
        {
            try
            {
                var resultOfDeleteZoonCan = await zoonCanOperation.DelteZoonCanAsync(zoonCanViewModel.ZoonCanId);
                if (!resultOfDeleteZoonCan)
                    throw new Exception();
                await RefreshDataGridViewAsync();
                MessageBox.Show("زونکن با موفقیت حذف شد");

            }
            catch (Exception ex)
            {
                MessageBox.Show("زونکن حذف نشد لطفا ابتدا فولدر های ان را حذف یا ویرایش کنید سپس اقدام به حذف کنید");
            }
        }
    }

    private void ShowFolder_Click(object sender, RoutedEventArgs e)
    {
        var zoonCanViewModel = (ZoonCanViewModel)ZDG_View.SelectedItem;
        if (zoonCanViewModel is not null)
        {
            var folderView = new FoldersView();
            folderView.ShowFolderByZoonCanDto = new ShowFolderByZoonCanDto
            {
                ZoonCanId = zoonCanViewModel.ZoonCanId,
                GeneratedCodeForZoonCan = zoonCanViewModel.ZoonCanGeneratedCode
            };
            Close();
            folderView.ShowDialog();
            return;
        }
        MessageBox.Show("لطفا سطری را انتخاب کنید");
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await fileOperation.DeleteAllFilesAsync(Directory.GetCurrentDirectory() + $"\\Images");
        await RefreshDataGridViewAsync();
    }
}
