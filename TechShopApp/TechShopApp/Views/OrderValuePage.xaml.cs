using TechShopApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderValuePage : ContentPage
    {
        public OrderValuePage()
        {
            InitializeComponent();
            BindingContext = new OrderValueViewModel();
        }
    }
}