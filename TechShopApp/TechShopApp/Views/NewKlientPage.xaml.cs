using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.KlientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewKlientPage : ContentPage
    {
        public KlientForView Item { get; set; }

        public NewKlientPage()
        {
            InitializeComponent();
            BindingContext = new NewKlientViewModel();
        }
    }
}