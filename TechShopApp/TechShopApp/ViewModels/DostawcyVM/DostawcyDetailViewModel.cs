using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.Views;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.DostawcyVM
{
    public class DostawcyDetailViewModel : AItemDetailsViewModel<KlientForView>
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
        public DostawcyDetailViewModel()
            : base("Opis Klienta")
        {
        }
        protected override async Task GoToUpdatePage()
            => await Shell.Current.GoToAsync($"{nameof(EditKlientPage)}?{nameof(EditDostawcyViewModel.ItemId)}={KlientId}");

        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                this.CopyProperties(item);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
