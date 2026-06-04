using WpfApp9.Interface;
using WpfApp9.Model.App;
using System.Windows.Input;

namespace WpfApp9.ViewModel
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel(INavigationService nav) : base(nav)
        {
            CloseCommand = new RelayCommand(
            () => _navigation.NavigateTo<MainWindowViewModel>());
        }
        public ICommand CloseCommand { get; }
        public string AppName => "ЦифрыЗнаешьНаберешь Pro Edition Max 2027";
        public string Version => "Версия 2.0 (со свагой)";
    }
}
