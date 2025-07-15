using System;
using System.Collections.Generic;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ZamowioneProduktVM
{
    [QueryProperty(nameof(ZamowienieId), "ZamowienieId")]
    public class NewZamowioneProduktyViewModel : ANewItemViewModel<ZamowioneProduktyForView>
    {
        #region Fields
        private int zamowienieId;
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

        public NewZamowioneProduktyViewModel() : base("Dodawanie zamówionych produktów")
        {
            selectedProdukt = new ProduktForView();
            listaProduktow = DependencyService.Get<AListDataStore<ProduktForView>>().items;
            DataZamowienia = DateTimeOffset.UtcNow.Date;
        }

        public override ZamowioneProduktyForView SetItem()
        {
            return new ZamowioneProduktyForView()
            {
                ZamowienieId = this.ZamowienieId,
                ProduktId = SelectedProdukt?.ProduktId ?? 0,
                Ilosc = this.Ilosc,
                CenaJednostkowa = this.CenaJednostkowa
            };
        }

        public override bool ValidateSave()
        {
            return SelectedProdukt != null
                && Ilosc > 0
                && CenaJednostkowa > 0;
        }
    }
}
