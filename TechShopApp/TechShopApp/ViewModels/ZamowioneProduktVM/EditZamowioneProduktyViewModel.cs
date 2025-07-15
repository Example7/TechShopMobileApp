using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ZamowioneProduktVM
{
    [QueryProperty(nameof(ZamowienieId), "zamowienieId")]
    [QueryProperty(nameof(ProduktId), "produktId")]
    public class EditZamowioneProduktyViewModel : AItemUpdateViewModel<ZamowioneProduktyForView>
    {
        #region Fields
        private int zamowienieId;
        private int produktId;
        private DateTimeOffset dataZamowienia;
        private int ilosc;
        private double cenaJednostkowa;
        private ProduktForView selectedProdukt;
        private List<ProduktForView> listaProduktow;
        #endregion
        #region Properties
        public int ZamowienieId
        {
            get => zamowienieId;
            set => SetProperty(ref zamowienieId, value);
        }
        public int ProduktId
        {
            get => produktId;
            set => SetProperty(ref produktId, value);
        }
        public DateTimeOffset DataZamowienia
        {
            get => dataZamowienia;
            set => SetProperty(ref dataZamowienia, value);
        }
        public int Ilosc
        {
            get => ilosc;
            set => SetProperty(ref ilosc, value);
        }
        public double CenaJednostkowa
        {
            get => cenaJednostkowa;
            set => SetProperty(ref cenaJednostkowa, value);
        }
        public List<ProduktForView> ListaProduktow
        {
            get
            {
                return listaProduktow;
            }
        }
        public ProduktForView SelectedProdukt
        {
            get => selectedProdukt;
            set
            {
                if (SetProperty(ref selectedProdukt, value))
                {
                    if (selectedProdukt != null)
                        CenaJednostkowa = selectedProdukt.Cena;
                    else
                        CenaJednostkowa = 0;
                }
            }
        }
        #endregion
        public EditZamowioneProduktyViewModel() : base("Edycja zamówionych produktów")
        {
            selectedProdukt = new ProduktForView();
            listaProduktow = DependencyService.Get<AListDataStore<ProduktForView>>().items;
        }

        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                if (item != null)
                {
                    ZamowienieId = item.ZamowienieId;
                    ProduktId = item.ProduktId;
                    ilosc = item.Ilosc;
                    cenaJednostkowa = item.CenaJednostkowa;

                    SelectedProdukt = ListaProduktow.FirstOrDefault(p => p.ProduktId == item.ProduktId);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public override ZamowioneProduktyForView SetItem()
            => new ZamowioneProduktyForView()
            {
                ZamowienieId = this.ZamowienieId,
                ProduktId = this.ProduktId,
                Ilosc = this.Ilosc,
                CenaJednostkowa = this.CenaJednostkowa
            };

        public override bool ValidateSave()
        {
            return SelectedProdukt != null
                && Ilosc > 0
                && CenaJednostkowa > 0;
        }
    }
}
