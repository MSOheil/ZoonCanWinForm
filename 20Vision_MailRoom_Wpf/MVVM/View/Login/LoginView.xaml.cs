namespace _20Vision_MailRoom_Wpf.MVVM.View.Login;
/// <summary>
/// Interaction logic for LoginView.xaml
/// </summary>
public partial class LoginView : Window
{
    public LoginView()
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
        Application.Current.Shutdown();
    }

    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        txtUser.Text = "";
        txtPass.Password = "";
        var mainForm = new MainView();
        Close();
        mainForm.ShowDialog();
    }
}
