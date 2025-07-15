using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TechShopApp.ViewModels
{
    public class LoginViewModel : BindableObject
    {
        private string username;
        private string password;
        private string errorMessage;

        public string Username
        {
            get => username;
            set { username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set { errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            Preferences.Set("admin", "123");
            LoginCommand = new Command(OnLogin);
        }

        private void OnLogin()
        {
            Preferences.Set("admin", "123");

            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Podaj nazwę użytkownika i hasło.";
                return;
            }

            string savedPassword = Preferences.Get(Username, string.Empty);

            if (savedPassword == Password)
            {
                Preferences.Set("jwt_token", "dummy_token");
                Shell.Current.GoToAsync("//ProduktPage");
            }
            else
            {
                ErrorMessage = "Nieprawidłowa nazwa użytkownika lub hasło.";
            }
        }
    }
}
