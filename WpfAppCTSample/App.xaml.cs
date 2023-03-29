using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace WpfAppCTSample
{
    public sealed partial class App : Application
    {
        // Bu kısım başka yerlerden bir servis çağırıldığında kulllanılıyor
        // Kısaltma yapılması için. 
        public new static App Current => (App)Application.Current;

        // Dependency Injection için Servis Tanımlaması
        public IServiceProvider Services { get; }
        
        // Uygulamada kullanılacak tüm servisler burasının altında tanımlanmalı

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindow>();

            // Diğer Pencereler Tekrar Tekrar Açılabilir
            // Bu yüzden AddTransient olmalı.
            services.AddTransient<OtherWindow>();

            return services.BuildServiceProvider();
        }

        // Ana Uygulama başlatılıyor.
        public App()
        {
            Services = ConfigureServices();

            var mainApp = Services.GetRequiredService<MainWindow>();
            mainApp.Show();

        }

    }
}
