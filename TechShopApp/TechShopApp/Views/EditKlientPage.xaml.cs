using TechShopApp.ViewModels.KlientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditKlientPage : ContentPage
    {
        public EditKlientPage()
        {
            InitializeComponent();
            BindingContext = new EditKlientViewModel();
        }
    }
}