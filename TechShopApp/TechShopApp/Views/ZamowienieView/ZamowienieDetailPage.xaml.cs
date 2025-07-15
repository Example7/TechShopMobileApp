using TechShopApp.ViewModels.ZamowienieVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views.ZamowienieView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZamowienieDetailPage : ContentPage
    {
        public ZamowienieDetailPage()
        {
            InitializeComponent();
            BindingContext = new ZamowienieDetailViewModel();
        }
    }
}