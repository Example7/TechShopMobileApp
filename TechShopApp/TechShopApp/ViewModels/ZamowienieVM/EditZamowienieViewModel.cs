using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ZamowienieVM
{
    public class EditZamowienieViewModel : AItemUpdateViewModel<ZamowienieForView>
    {
        #region Fields
        private int zamowienieId;
        private int? klientId;
        private DateTime dataZamowienia;
        private string status;
        private double kwota;
        private KlientForView selectedKlient;
        private List<KlientForView> klienci;
        #endregion
        #region Properties
        public int ZamowienieId
        {
            get => zamowienieId;
            set => SetProperty(ref zamowienieId, value);
        }
        public int? KlientId
        {
            get => klientId;
            set => SetProperty(ref klientId, value);
        }
        public DateTime DataZamowienia
        {
            get => dataZamowienia;
            set => SetProperty(ref dataZamowienia, value);
        }
        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }
        public double Kwota
        {
            get => kwota;
            set => SetProperty(ref kwota, value);
        }
        public KlientForView SelectedKlient
        {
            get => selectedKlient;
            set => SetProperty(ref selectedKlient, value);
        }
        public List<KlientForView> Klienci
        {
            get => klienci;
        }
        #endregion
        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                if (item != null)
                {
                    ZamowienieId = item.ZamowienieId;
                    Status = item.Status;
                    Kwota = item.Kwota;
                    if (item.DataZamowienia != default)
                        DataZamowienia = item.DataZamowienia.DateTime;

                    SelectedKlient = Klienci.FirstOrDefault(k => k.KlientId == item.KlientId);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public override bool ValidateSave()
            => new[] { Status }.All(s => !string.IsNullOrWhiteSpace(s));

        public EditZamowienieViewModel()
            : base("Edycja zamówienia!")
        {
            selectedKlient = new KlientForView();
            klienci = DependencyService.Get<AListDataStore<KlientForView>>().items;
        }
        public override ZamowienieForView SetItem()
            => new ZamowienieForView()
            {
                ZamowienieId = this.ZamowienieId,
                KlientId = this.selectedKlient?.KlientId ?? 0,
                DataZamowienia = new DateTimeOffset(this.DataZamowienia),
                Status = this.Status,
                Kwota = this.Kwota
            };      
    }
}
