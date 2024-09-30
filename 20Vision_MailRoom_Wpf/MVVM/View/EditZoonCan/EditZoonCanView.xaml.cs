namespace _20Vision_MailRoom_Wpf.MVVM.View.EditZoonCan;
/// <summary>
/// Interaction logic for EditZoonCanView.xaml
/// </summary>
public partial class EditZoonCanView : Window
{
    public ZoonCanViewModel? ZoonCanViewModel { get; set; }
    private readonly IZoonCanOperation zoonCanOperation;
    public EditZoonCanView()
    {
        InitializeComponent();
        zoonCanOperation = new ZoonCanOperation();

    }
    private void SelectedItem()
    {
        zoonCanInsertDate.SelectedDate = new PersianDate(Convert.ToDateTime(ZoonCanViewModel.ZoonCanInsertDate));
        ZoonCan_Description.Text = ZoonCanViewModel.ZoonCanDescription;
        ZoonCan_Name.Text = ZoonCanViewModel.ZoonCanName;
        ClrPcker_Background.SelectedColor = (Color)ColorConverter.ConvertFromString(System.Drawing.ColorTranslator.FromHtml(ZoonCanViewModel.ZoonCanColor.ToString()).Name);
        zoonCan_GenereatedCode.Text = ZoonCanViewModel.ZoonCanGeneratedCode.ToString();
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
    private async void ZoonCan_Edit_Btn_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ZoonCan_Description.Text))
        {
            MessageBox.Show("لطفا توضیحات  زونکن را وارد کنید");
            return;
        }
        if (string.IsNullOrWhiteSpace(ZoonCan_Name.Text))
        {
            MessageBox.Show("لطفا نام زونکن را وارد کنید");
            return;
        }
        if (string.IsNullOrWhiteSpace(zoonCan_GenereatedCode.Text))
        {
            MessageBox.Show("لطفا کد زونکن را وارد کنید");
            return;
        }
        try
        {
            var resultOfEdit = await zoonCanOperation.UpdateZoonCanAsync<UpdateZoonCanDto>(new UpdateZoonCanDto
            {
                GeneratedCodeForZoonCan = int.Parse(zoonCan_GenereatedCode.Text),
                ZoonCanName = ZoonCan_Name.Text,
                ZoonCanDescription = ZoonCan_Description.Text,
                ZoonCanColor = ClrPcker_Background.SelectedColor.ToString(),
                ZoonCanInsertDate = zoonCanInsertDate.SelectedDate.ToString(),
                ZoonCanId = ZoonCanViewModel.ZoonCanId
            });
            MessageBox.Show("زونکن با موفقیت ویرایش شد");
            var zoonCanView = new ZoonCanView();
            Close();
            zoonCanView.ShowDialog();
        }
        catch (Exception)
        {
            MessageBox.Show("زونکن ویرایش نشد");
            throw;
        }

    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }
    private void EditZoonCan_Loaded(object sender, RoutedEventArgs e)
    {
        SelectedItem();
    }

}
