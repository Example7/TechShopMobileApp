using TechShopApp.ViewModels.ZamowioneProduktVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views.ZamowioneProduktyView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ZamowioneProduktyDetailPage : ContentPage
	{
		public ZamowioneProduktyDetailPage()
		{
			InitializeComponent();
            BindingContext = new ZamowioneProduktDetailViewModel();
        }
	}
}