namespace _20Vision_MailRoom_Wpf.MVVM.View.Document.AddDocument;

/// <summary>
/// Interaction logic for AddDocumentView.xaml
/// </summary>
public partial class AddDocumentView : Window
{
    public Guid FolderId { get; set; }
    public Guid ZoonCanId { get; set; }
    private readonly IDocumentOperation documentOperation;
    public AddDocumentView()
    {
        InitializeComponent();
        documentOperation = new DocumentOperation();
    }

    private async void AddDcoument_Btn_Click(object sender, RoutedEventArgs e)
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
        try
        {
            var resultOfAdd = await documentOperation.AddDocumentAsync<ShowDocumentDto>(new CreateDocumentDto
            {
                DocumentDescription = Document_Description.Text,
                DocumentName = Document_Name.Text,
                FolderId = FolderId,
                GeneratedCodeForDocument = 0,
                InsertDocumentDate = DocumentInsertDate.SelectedDate.ToString()
            });
            MessageBox.Show("سند با موفقیت ثبت شد");
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("زونکن ثبت نشد");
            return;
        }

    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }
}
