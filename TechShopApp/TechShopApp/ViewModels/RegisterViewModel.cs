using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Input;
using Xamarin.Forms;

namespace TechShopApp.ViewModels
{
    public class RegisterViewModel : BindableObject
    {
        private string email;
        private string password;
        private string confirmPassword;
        private string errorMessage;

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(); }
        }

        public string ConfirmPassword
        {
            get => confirmPassword;
            set { confirmPassword = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set { errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand RegisterCommand { get; }

        private readonly HttpClient _httpClient;

        public RegisterViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7063/") };
            RegisterCommand = new Command(OnRegister);
        }

        private async void OnRegister()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                ErrorMessage = "Wypełnij wszystkie pola.";
                return;
            }

            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Hasła nie są takie same.";
                return;
            }

            try
            {
                var registerDto = new { Email = Email, Haslo = Password };

                var response = await _httpClient.PostAsJsonAsync("api/Auth/register", registerDto);

                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    ErrorMessage = "Błąd rejestracji: " + errorContent;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Błąd połączenia z serwerem: " + ex.Message;
            }
        }
    }
}
