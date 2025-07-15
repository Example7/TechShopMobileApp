using TechShopApp.ViewModels.DostawyVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views.DostawyView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDostawyPage : ContentPage
    {
        public EditDostawyPage()
        {
            InitializeComponent();
            BindingContext = new EditDostawyViewModel();
        }
    }
}