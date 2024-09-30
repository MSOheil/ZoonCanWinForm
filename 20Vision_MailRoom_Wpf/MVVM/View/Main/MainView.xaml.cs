namespace _20Vision_MailRoom_Wpf.MVVM.View.Main;
/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
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

    private void LogOut_Click(object sender, RoutedEventArgs e)
    {
        var loginForm = new LoginView();
        this.Close();
        loginForm.ShowDialog();
    }
  
}
