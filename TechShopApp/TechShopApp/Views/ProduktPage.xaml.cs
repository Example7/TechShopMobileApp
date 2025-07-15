using TechShopApp.ViewModels.ProduktVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProduktPage : ContentPage
    {
        private ProduktViewModel _viewModel;

        public ProduktPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ProduktViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}