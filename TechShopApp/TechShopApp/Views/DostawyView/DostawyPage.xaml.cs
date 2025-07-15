using TechShopApp.ViewModels.DostawyVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views.DostawyView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DostawyPage : ContentPage
    {
        private DostawyViewModel _viewModel;

        public DostawyPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new DostawyViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}