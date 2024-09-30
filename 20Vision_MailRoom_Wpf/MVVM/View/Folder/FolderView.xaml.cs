namespace _20Vision_MailRoom_Wpf.MVVM.View.Folder;

/// <summary>
/// Interaction logic for FolderView.xaml
/// </summary>
public partial class FolderView : Window
{
    public FolderView()
    {
        InitializeComponent();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }
}
