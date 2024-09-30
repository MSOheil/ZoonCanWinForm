namespace _20Vision_MailRoom_Wpf.MVVM.View.Main;
/// <summary>
/// Interaction logic for HomeView.xaml
/// </summary>
public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }
    private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var zoonCanView = new ZoonCanView();
        Window parentWindow = Window.GetWindow(this);
        parentWindow.Close();
        zoonCanView.ShowDialog();
    }
}
