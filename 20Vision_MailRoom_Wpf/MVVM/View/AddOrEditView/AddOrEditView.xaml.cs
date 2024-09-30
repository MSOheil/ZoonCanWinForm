namespace _20Vision_MailRoom_Wpf.MVVM.View.AddOrEdit;
/// <summary>
/// Interaction logic for AddOrEditView.xaml
/// </summary>
public partial class AddOrEditView : Window
{
    private readonly IZoonCanOperation zoonCanOperation;
    public ZoonCanViewModel? zoonCanViewModel { get; set; }
    public AddOrEditView()
    {
        InitializeComponent();
        zoonCanOperation = new ZoonCanOperation();
    }
    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        var zoonCanView = new ZoonCanView();
        Close();
        zoonCanView.ShowDialog();
    }

    private async void AddZoonCan_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(zoonCan_Name.Text))
        {
            MessageBox.Show("لطفا نام زونکن را وارد کنید");
            return;
        }
        if (string.IsNullOrWhiteSpace(ZoonCan_Description.Text))
        {
            MessageBox.Show("لطفا توضیحات زونکن را وارد کنید");
            return;
        }
        var colorName = ClrPcker_Background.SelectedColor.ToString();
        if (string.IsNullOrWhiteSpace(colorName))
        {
            MessageBox.Show("لطفا رنگ زونکن را انتخاب کنید ");
            return;
        }
        try
        {
            await zoonCanOperation.AddZoonCanOperationAsync(zoonCan_Name.Text, colorName, ZoonCan_Description.Text, zoonCanInsertDate.SelectedDate.ToString());
            MessageBox.Show("زونکن با موفقیت ثبت شد");
            var zoonCanView = new ZoonCanView();
            Close();
            zoonCanView.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show("زونکن اضافه نشد");
            return;
        }

    }

    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {

    }
}
