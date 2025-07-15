using TechShopApp.ViewModels.ZamowioneProduktVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views.ZamowioneProduktyView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewZamowioneProduktyPage : ContentPage
	{
		public NewZamowioneProduktyPage ()
		{
			InitializeComponent ();
            BindingContext = new NewZamowioneProduktyViewModel();
        }
	}
}