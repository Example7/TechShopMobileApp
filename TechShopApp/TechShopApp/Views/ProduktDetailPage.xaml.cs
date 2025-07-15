using TechShopApp.ViewModels.ItemVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProduktDetailPage : ContentPage
    {
        public ProduktDetailPage()
        {
            InitializeComponent();
            BindingContext = new ProduktDetailViewModel();
        }
    }
}