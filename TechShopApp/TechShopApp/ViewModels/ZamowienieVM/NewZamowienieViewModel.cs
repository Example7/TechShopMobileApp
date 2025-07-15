using System;
using System.Collections.Generic;
using System.Linq;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ZamowienieVM
{
    public class NewZamowienieViewModel : ANewItemViewModel<ZamowienieForView>
    {
        #region Fields
        private int zamowienieId;
        private DateTimeOffset dataZamowienia;
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
        public DateTimeOffset DataZamowienia
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
            set => SetProperty(ref  selectedKlient, value);
        }
        public List<KlientForView> Klienci
        {
            get => klienci;
        }
        #endregion

        public override bool ValidateSave()
            => new[] { Status }.All(s => !string.IsNullOrWhiteSpace(s));

        public NewZamowienieViewModel() : base("Dodaj Zamówienie") 
        {
            selectedKlient = new KlientForView();
            klienci = DependencyService.Get<AListDataStore<KlientForView>>().items;
            DataZamowienia = DateTimeOffset.UtcNow.Date;
        }

        public override ZamowienieForView SetItem()
             => new ZamowienieForView()
             {
                 ZamowienieId = new Random().Next(),
                 KlientId = SelectedKlient.KlientId
             }
            .CopyProperties(this);
    }
}
