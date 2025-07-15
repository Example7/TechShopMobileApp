using System.Windows.Input;
using Xamarin.Forms;

namespace TechShopApp.ViewModels
{
    public class StartupViewModel : BindableObject
    {
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public StartupViewModel()
        {
            LoginCommand = new Command(OnLogin);
            RegisterCommand = new Command(OnRegister);
        }

        private async void OnLogin()
        {
            await Shell.Current.GoToAsync("LoginPage");
        }

        private async void OnRegister()
        {
            await Shell.Current.GoToAsync("RegisterPage");
        }
    }
}
