using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.ItemVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewProduktPage : ContentPage
    {
        public ProduktForView Item { get; set; }

        public NewProduktPage()
        {
            InitializeComponent();
            BindingContext = new NewProduktViewModel();
        }
    }
}