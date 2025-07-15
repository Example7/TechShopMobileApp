using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.DostawyVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views.DostawyView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDostawyPage : ContentPage
    {
        public DostawyForView Item { get; set; }

        public NewDostawyPage()
        {
            InitializeComponent();
            BindingContext = new NewDostawyViewModel();
        }
    }
}