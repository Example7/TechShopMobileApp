using TechShopApp.ViewModels.KlientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KlientDetailPage : ContentPage
    {
        public KlientDetailPage()
        {
            InitializeComponent();
            BindingContext = new KlientDetailViewModel();
        }
    }
}