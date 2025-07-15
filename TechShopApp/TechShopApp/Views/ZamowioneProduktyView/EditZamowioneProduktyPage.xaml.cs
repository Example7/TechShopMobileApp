using TechShopApp.ViewModels.ZamowioneProduktVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechShopApp.Views.ZamowioneProduktyView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditZamowioneProduktyPage : ContentPage
	{
		public EditZamowioneProduktyPage ()
		{
			InitializeComponent ();
            BindingContext = new EditZamowioneProduktyViewModel();
        }
	}
}