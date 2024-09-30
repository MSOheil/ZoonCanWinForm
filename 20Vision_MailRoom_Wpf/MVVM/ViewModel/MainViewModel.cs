namespace _20Vision_MailRoom_Wpf.MVVM.ViewModel;
public class MainViewModel : ObservableObject
{
    public HomeViewModel HomeVm { get; set; }
    private object currentView;
    public object CurrentView
    {
        get { return currentView; }
        set
        {
            currentView = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        HomeVm = new HomeViewModel();
        CurrentView = HomeVm;
    }
}
