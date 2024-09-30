namespace _20Vision_MailRoom_Wpf.MVVM.View.Document.AddDocument;

/// <summary>
/// Interaction logic for EditDocumentView.xaml
/// </summary>
public partial class EditDocumentView : Window
{
    public ShowDocumentViewModel ShowDocumentViewModel { get; set; }
    public int GeneratedCodeForFolder { get; set; }
    private readonly IDocumentOperation documentOperation;
    public EditDocumentView()
    {
        InitializeComponent();
        documentOperation = new DocumentOperation();
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void AddDocument_Btn(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Document_Name.Text))
        {
            MessageBox.Show("لطفا نام سند را وارد کنید");
            return;
        }
        if (string.IsNullOrWhiteSpace(Document_Description.Text))
        {
            MessageBox.Show("لطفا توضیحات سند را وارد کنید");
            return;
        }
        if (string.IsNullOrWhiteSpace(Folder_GeneratedCode.Text))
        {
            MessageBox.Show("لطفا کد فولدر را وارد کنید");
            return;
        }
        try
        {
            documentOperation.UpdateDocumentAsync<ShowDocumentDto>(new UpdateDocumentDto
            {
                DocumentId = ShowDocumentViewModel.DocumentId,
                DocumentDescription = Document_Description.Text,
                DocumentName = Document_Name.Text,
                FolderId = ShowDocumentViewModel.FolderId,
                GeneratedCodeForDocument = int.Parse(Document_Generatedcode.Text),
                InsertDocumentDate = DocumentInsertDate.SelectedDate.ToString(),
                GeneratedCodeForFolder = int.Parse(Folder_GeneratedCode.Text)
            });
            MessageBox.Show("ویرایش با موفقیت انجام شد");
            Close();
        }
        catch (Exception)
        {
            MessageBox.Show("ویرایش با موفقیت انجام نشد");
            Close();
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
    private void InitialView()
    {
        Document_Name.Text = ShowDocumentViewModel.DocumentName;
        Document_Generatedcode.Text = ShowDocumentViewModel.GeneratedCodeForDocument.ToString();
        Folder_GeneratedCode.Text = GeneratedCodeForFolder.ToString();
        Document_Description.Text = ShowDocumentViewModel.DocumentDescription;
        DocumentInsertDate.SelectedDate = new PersianDate(Convert.ToDateTime(ShowDocumentViewModel.InsertDocumentDate));
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        InitialView();
    }
}
