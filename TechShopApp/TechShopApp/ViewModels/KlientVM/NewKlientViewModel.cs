using System.Linq;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.Abstract;

namespace TechShopApp.ViewModels.KlientVM
{
    public class NewKlientViewModel : ANewItemViewModel<KlientForView>
    {
        #region Fields
        private int klientID;
        private string imie;
        private string nazwisko;
        private string email;
        private string telefon;
        private string adres;
        #endregion
        #region Properties
        public int KlientID
        {
            get => klientID;
            set => SetProperty(ref klientID, value);
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

        public override bool ValidateSave()
            => new[] { Imie, Nazwisko, Email, Telefon, Adres }.All(s => !string.IsNullOrWhiteSpace(s));

        public NewKlientViewModel() : base("Dodaj Klienta") { }

        public override KlientForView SetItem()
             => new KlientForView().CopyProperties(this);
    }
}
