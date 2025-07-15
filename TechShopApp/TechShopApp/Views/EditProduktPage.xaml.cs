using TechShopApp.ViewModels.ItemVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProduktPage : ContentPage
    {
        public EditProduktPage()
        {
            InitializeComponent();
            BindingContext = new EditProduktViewModel();
        }
    }
}