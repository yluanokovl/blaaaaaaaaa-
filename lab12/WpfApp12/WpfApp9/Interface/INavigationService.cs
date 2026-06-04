using WpfApp9.Model.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9.Interface
{
    public interface INavigationService
    {
        ViewModelBase? CurrentViewModel { get; }
        void NavigateTo<T>(object? parameter = null) 
        where T : ViewModelBase;
    }
}
