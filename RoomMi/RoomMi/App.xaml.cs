using Microsoft.Extensions.DependencyInjection;
using RoomMi.Vista.Dialogos;
using System.Configuration;
using System.Data;
using System.Windows;

namespace RoomMi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();

            ConfigureServices(services);

            _serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Login>();
            services.AddTransient<MainWindow>();
            services.AddTransient<RecuperarPassword>();
            services.AddTransient<GestionReservas>();
            services.AddTransient<Func<GestionReservas>>(serviceProvider => () => serviceProvider.GetRequiredService<GestionReservas>());
            services.AddTransient<Func<Login>>(serviceProvider => () => serviceProvider.GetRequiredService<Login>());
            services.AddTransient<Func<MainWindow>>(serviceProvider => () => serviceProvider.GetRequiredService<MainWindow>());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Login login = _serviceProvider.GetRequiredService<Login>();

            ShutdownMode = ShutdownMode.OnMainWindowClose;

            login.Show();
        }
    }

}
