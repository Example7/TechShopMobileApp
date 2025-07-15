using TechShopApp.ViewModels.KlientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KlientPage : ContentPage
    {
        private KlientViewModel _viewModel;

        public KlientPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new KlientViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}