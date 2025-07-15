using System;
using TechShopApp.Views;
using TechShopApp.Views.DostawyView;
using TechShopApp.Views.ZamowienieView;
using TechShopApp.Views.ZamowioneProduktyView;
using Xamarin.Forms;

namespace TechShopApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(StartupPage), typeof(StartupPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));

            Routing.RegisterRoute(nameof(ProduktDetailPage), typeof(ProduktDetailPage));
            Routing.RegisterRoute(nameof(NewProduktPage), typeof(NewProduktPage));
            Routing.RegisterRoute(nameof(EditProduktPage), typeof(EditProduktPage));

            Routing.RegisterRoute(nameof(KlientDetailPage), typeof(KlientDetailPage));
            Routing.RegisterRoute(nameof(NewKlientPage), typeof(NewKlientPage));
            Routing.RegisterRoute(nameof(EditKlientPage), typeof(EditKlientPage));

            Routing.RegisterRoute(nameof(DostawyDetailPage), typeof(DostawyDetailPage));
            Routing.RegisterRoute(nameof(NewDostawyPage), typeof(NewDostawyPage));
            Routing.RegisterRoute(nameof(EditDostawyPage), typeof(EditDostawyPage));

            Routing.RegisterRoute(nameof(ZamowienieDetailPage), typeof(ZamowienieDetailPage));
            Routing.RegisterRoute(nameof(NewZamowieniePage), typeof(NewZamowieniePage));
            Routing.RegisterRoute(nameof(EditZamowieniePage), typeof(EditZamowieniePage));

            Routing.RegisterRoute(nameof(ZamowioneProduktyDetailPage), typeof(ZamowioneProduktyDetailPage));
            Routing.RegisterRoute(nameof(NewZamowioneProduktyPage), typeof(NewZamowioneProduktyPage));
            Routing.RegisterRoute(nameof(EditZamowioneProduktyPage), typeof(EditZamowioneProduktyPage));

            Routing.RegisterRoute(nameof(OrderValuePage), typeof(OrderValuePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//StartupPage");
        }
    }
}
