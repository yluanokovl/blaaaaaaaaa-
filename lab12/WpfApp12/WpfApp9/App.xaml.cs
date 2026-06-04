using WpfApp9.Interface;
using WpfApp9.Services;
using WpfApp9.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            // 2. Регистрируем сервисы (Lifetime)
            // Service — Singleton, так как он не хранит состояние пользователя.
            services.AddSingleton<IDialogService, WPFDialogService>();
            services.AddSingleton<INavigationService, NavigationService>();
            // 3. ViewModel — Transient (при навигации нам будут нужны новые экземпляры)
            services.AddSingleton<ContactListViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<ContactEditViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            // 4. Главное окно — Singleton с явной передачей
            // DataContext через лямбда-выражение
            services.AddSingleton<MainWindow>(sp => {
                var window = new MainWindow();
                window.DataContext = sp.GetRequiredService<MainWindowViewModel>();
                return window;
            });

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    "Data Source=DBSRV\\OV2025;Initial Catalog=PhoneBookDB_Shelkovn_2307b;Integrated Security=True;TrustServerCertificate=True"));
            // 5. Создаём контейнер (ServiceProvider)
            var serviceProvider =
            services.BuildServiceProvider();
            // 6. Получаем главное окно и запускаем его
            var mainWindow =
            serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
