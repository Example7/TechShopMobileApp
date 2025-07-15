using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.Views;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.KlientVM
{
    public class KlientDetailViewModel : AItemDetailsViewModel<KlientForView>
    {
        #region Fields
        private int klientId;
        private string imie;
        private string nazwisko;
        private string email;
        private string telefon;
        private string adres;
        #endregion
        #region Properties
        public int KlientId
        {
            get => klientId;
            set => SetProperty(ref klientId, value);
        }
        public string Imie
        {
            get => imie;
            set => SetProperty(ref imie, value);
        }
        public string Nazwisko
        {
            get => nazwisko;
            set => SetProperty(ref nazwisko, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Telefon
        {
            get => telefon;
            set => SetProperty(ref telefon, value);
        }
        public string Adres
        {
            get => adres;
            set => SetProperty(ref adres, value);
        }
        #endregion
        public KlientDetailViewModel()
            : base("Opis Klienta")
        {
        }
        protected override async Task GoToUpdatePage()
            => await Shell.Current.GoToAsync($"{nameof(EditKlientPage)}?{nameof(EditKlientViewModel.ItemId)}={KlientId}");

        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                KlientId = item.KlientId;
                Imie = item.Imie;
                Nazwisko = item.Nazwisko;
                Email = item.Email;
                Telefon = item.Telefon;
                Adres = item.Adres;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
