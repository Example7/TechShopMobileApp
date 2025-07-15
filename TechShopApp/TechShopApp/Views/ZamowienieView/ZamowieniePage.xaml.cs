using TechShopApp.ViewModels.ZamowienieVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views.ZamowienieView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZamowieniePage : ContentPage
    {
        private ZamowienieViewModel _viewModel;

        public ZamowieniePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ZamowienieViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}