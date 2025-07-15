using System.Net.Http;
using TechShopApp.ServiceReference;
using TechShopApp.Services;
using Xamarin.Forms;

namespace TechShopApp
{
    public partial class App : Application
    {
        public App()
        {
            var handler = new HttpClientHandler();
#if DEBUG
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (HttpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
#endif
            var client = new HttpClient(handler);

            InitializeComponent();

            DependencyService.RegisterSingleton(new TechShopService("https://localhost:7063", client));
            DependencyService.Register<ProduktDataStore>();
            DependencyService.Register<KlientDataStore>();
            DependencyService.Register<DostawyDataStore>();
            DependencyService.Register<DostawcyDataStore>();
            DependencyService.Register<KategorieDataStore>();
            DependencyService.Register<ZamowienieDataStore>();
            DependencyService.Register<ZamowioneProduktyDataStore>();
            DependencyService.Register<OrderValueDataStore>();

            MainPage = new AppShell();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.GoToAsync("//StartupPage");
            });
        }

        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}
