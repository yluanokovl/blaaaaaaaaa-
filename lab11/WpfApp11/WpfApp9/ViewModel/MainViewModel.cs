using WpfApp9.Interface;
using WpfApp9.Model.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WpfApp9.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public INavigationService NavigationService
        {
            get => _navigation;
        }
        public MainWindowViewModel(INavigationService navigation) : base(navigation)
        {
            ShowContactsCommand = new RelayCommand(
            () => _navigation.NavigateTo<ContactListViewModel>());
            ShowAboutCommand = new RelayCommand(
            () => _navigation.NavigateTo<AboutViewModel>());
            _navigation.NavigateTo<ContactListViewModel>();
        }
        public ICommand ShowContactsCommand { get; }
        public ICommand ShowAboutCommand { get; }
    }
}
