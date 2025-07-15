using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.Views.ZamowioneProduktyView;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ZamowioneProduktVM
{
    [QueryProperty(nameof(ZamowienieIdString), "ZamowienieId")]
    [QueryProperty(nameof(ProduktIdString), "ProduktId")]
    public class ZamowioneProduktDetailViewModel : AItemDetailsViewModel<ZamowioneProduktyForView>
    {
        #region Fields
        private int? zamowienieId;
        private int? produktId;
        private string zamowienieIdString;
        private string produktIdString;
        private int ilosc;
        private double cenaJednostkowa;
        private ProduktForView selectedProdukt;
        private List<ProduktForView> listaProduktow;
        public Command DeleteCommand { get; }
        #endregion
        #region Properties
        public string ZamowienieIdString
        {
            get => zamowienieIdString;
            set
            {
                zamowienieIdString = value;
                if (int.TryParse(value, out int val))
                {
                    ZamowienieId = val;
                    _ = TryLoadItemAsync();
                }
                else
                {
                    ZamowienieId = null;
                }
            }
        }

        public string ProduktIdString
        {
            get => produktIdString;
            set
            {
                produktIdString = value;
                if (int.TryParse(value, out int val))
                {
                    ProduktId = val;
                    _ = TryLoadItemAsync();
                }
                else
                {
                    ProduktId = null;
                }
            }
        }

        public int? ZamowienieId
        {
            get => zamowienieId;
            set => SetProperty(ref zamowienieId, value);
        }

        public int? ProduktId
        {
            get => produktId;
            set => SetProperty(ref produktId, value);
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
        public List<ProduktForView> ListaProduktow => listaProduktow;

        public ProduktForView SelectedProdukt
        {
            get => selectedProdukt;
            set
            {
                if (SetProperty(ref selectedProdukt, value))
                {
                    CenaJednostkowa = selectedProdukt?.Cena ?? 0;
                }
            }
        }
        #endregion

        public ZamowioneProduktDetailViewModel()
            : base("Szczegóły zamówionych produktów")
        {
            selectedProdukt = new ProduktForView();
            listaProduktow = DependencyService.Get<AListDataStore<ProduktForView>>().items;

            DeleteCommand = new Command(async () => await ExecuteDeleteCommand());
        }

        private async Task TryLoadItemAsync()
        {
            if (ZamowienieId.HasValue && ProduktId.HasValue)
            {
                await LoadItem(ZamowienieId.Value, ProduktId.Value);
            }
        }

        public override Task LoadItem(int id)
        {
            throw new NotImplementedException("LoadItem(int id) is not supported for this ViewModel. Use LoadItem(int zamowienieId, int produktId) instead.");
        }

        public async Task LoadItem(int zamowienieId, int produktId)
        {
            try
            {
                var item = await ((IZamowioneProduktyDataStore)DataStore).GetItemAsync(zamowienieId, produktId);
                if (item != null)
                {
                    ZamowienieId = item.ZamowienieId;
                    ProduktId = item.ProduktId;
                    Ilosc = item.Ilosc;
                    CenaJednostkowa = item.CenaJednostkowa;
                    this.CopyProperties(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to Load Item: {ex.Message}");
            }
        }

        protected override async Task GoToUpdatePage()
            => await Shell.Current.GoToAsync($"{nameof(EditZamowioneProduktyPage)}?ZamowienieId={ZamowienieId}&ProduktId={ProduktId}");

        private async Task ExecuteDeleteCommand()
        {
            if (ZamowienieId.HasValue && ProduktId.HasValue)
            {
                bool success = await ((IZamowioneProduktyDataStore)DataStore)
                    .DeleteItemAsync(ZamowienieId.Value, ProduktId.Value);

                if (success)
                {
                    // Wracamy do poprzedniej strony lub innego widoku po usunięciu
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Błąd", "Nie udało się usunąć elementu.", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Błąd", "Brak klucza do usunięcia.", "OK");
            }
        }
    }
}
