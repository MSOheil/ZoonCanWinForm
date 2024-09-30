namespace _20Vision_MailRoom_Wpf.MVVM.View.Document.ShowDocuments;
/// <summary>
/// Interaction logic for DocumentView.xaml
/// </summary>
public partial class DocumentView : Window
{
    public FolderViewModel FolderViewModel { get; set; }
    private readonly IDocumentOperation documentOperation;
    private readonly IFileOperation fileOperation;
    public DocumentView()
    {
        InitializeComponent();
        documentOperation = new DocumentOperation();
        fileOperation = new FileOperation();
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }
    private async Task UpdateDataGridAsync()
    {
        var documents = await documentOperation.GetAllDocumentAsync<PaginatedList<ShowDocumentDto>>(new GetAllDocumentDto
        {
            PageNumber = 1,
            PageSize = 20,
            FolderId = FolderViewModel.FolderId
        });

        var documentViewModel = new ObservableCollection<ShowDocumentViewModel>();
        foreach (var document in documents.Items)
        {
            documentViewModel.Add(new ShowDocumentViewModel
            {
                DocumentDescription = document.DocumentDescription,
                DocumentName = document.DocumentName,
                FolderId = document.FolderId,
                GeneratedCodeForDocument = document.GeneratedCodeForDocument,
                InsertDocumentDate = document.InsertDocumentDate,
                DocumentId = document.DocumentId
            });
        }
        DDV_View.ItemsSource = documentViewModel;

    }
    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        var showFolderView = new FoldersView();
        showFolderView.ShowFolderByZoonCanDto = new ShowFolderByZoonCanDto
        {
            GeneratedCodeForZoonCan = FolderViewModel.GeneratedCodeForZoonCan,
            ZoonCanId = FolderViewModel.ZoonCanId,
        };
        Close();
        showFolderView.ShowDialog();

    }

    private void EditFolder_Click(object sender, RoutedEventArgs e)
    {

    }

    private void DeleteFolder_Click(object sender, RoutedEventArgs e)
    {

    }

    private async void ShowDocument_Btn_Click(object sender, RoutedEventArgs e)
    {
        var document = (ShowDocumentViewModel)DDV_View.SelectedItem;
        if (document is not null)
        {
            var documentImageView = new DocumentImageView();
            documentImageView.DocumentId = document.DocumentId;
            documentImageView.ShowDialog();
            await fileOperation.DeleteAllFilesAsync(Directory.GetCurrentDirectory() + $"\\Images");
            return;
        }
        MessageBox.Show("لطفا سطری را برای نمایش انتخاب کنید");
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private async void Window_Loade(object sender, RoutedEventArgs e)
    {
        await UpdateDataGridAsync();
    }

    private async void DeleteDocument_Click(object sender, RoutedEventArgs e)
    {
        var document = (ShowDocumentViewModel)DDV_View.SelectedItem;
        if (document is not null)
        {
            try
            {
                var resultOfDeleteDocument = await documentOperation.DeleteDocumentAsync<bool>(new DeleteDocumentDto
                {
                    DocumentId = document.DocumentId
                });
                await UpdateDataGridAsync();
                MessageBox.Show("سند با موفقیت حذف شد");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("سند با موفقیت حذف نشد");
                return;
            }
        }
        MessageBox.Show("لطفا سطری را برای حذف انتخاب کنید");
    }

    private async void EditDocument_Click(object sender, RoutedEventArgs e)
    {

        var documentViewMode = (ShowDocumentViewModel)DDV_View.SelectedItem;
        if (documentViewMode is not null)
        {
            var editView = new EditDocumentView();
            editView.ShowDocumentViewModel = documentViewMode;
            editView.GeneratedCodeForFolder = FolderViewModel.GeneratedCodeForFolder;
            editView.ShowDialog();
            await UpdateDataGridAsync();
            return;
        }
        MessageBox.Show("لطفا سطری را برای ویرایش انتخاب کنید");
    }

    private async void AddDocument_Click(object sender, RoutedEventArgs e)
    {
        var addDocumentView = new AddDocumentView();
        addDocumentView.FolderId = FolderViewModel.FolderId;
        addDocumentView.ZoonCanId = FolderViewModel.ZoonCanId;
        addDocumentView.ShowDialog();
        await UpdateDataGridAsync();
    }
}
