using WpfApp9.Interface;
using WpfApp9.Model.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private ViewModelBase? _currentViewModel;
        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                OnPropertyChanged();

            }
        }
        public void NavigateTo<T>(object? parameter = null) where T : ViewModelBase
        {
            // 1. Получаем ViewModel из контейнера DI
            var vm = _serviceProvider.GetRequiredService<T>();
            // 2. Если ViewModel поддерживает прием параметров (опционально)
            vm.OnNavigatedTo(parameter);
            // 3. Обновляем CurrentViewModel. ContentControl подхватит изменение.
            CurrentViewModel = vm;
        }
    }
}
