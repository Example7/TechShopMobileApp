using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.Views.ZamowienieView;
using TechShopApp.Views.ZamowioneProduktyView;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ZamowienieVM
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ZamowienieDetailViewModel : AItemDetailsViewModel<ZamowienieForView>
    {
        #region Fields
        public ZamowioneProduktyDataStore ZamowioneProduktyDataStore => DependencyService.Get<ZamowioneProduktyDataStore>();
        private ZamowioneProduktyForView _selectedItem;
        private int zamowienieId;
        private string klientData;
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
        public string KlientData
        {
            get => klientData;
            set => SetProperty(ref klientData, value);
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
            set => SetProperty(ref selectedKlient, value);
        }
        public List<KlientForView> Klienci
        {
            get => klienci;
        }

        public ObservableCollection<ZamowioneProduktyForView> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ZamowioneProduktyForView> ItemTapped { get; }
        public ZamowioneProduktyForView SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        #endregion
        public ZamowienieDetailViewModel()
            : base("Opis Zamowienia")
        {
            DataZamowienia = DateTime.UtcNow.Date;
            selectedKlient = new KlientForView();
            klienci = DependencyService.Get<AListDataStore<KlientForView>>().items;

            Items = new ObservableCollection<ZamowioneProduktyForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<ZamowioneProduktyForView>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = ZamowioneProduktyDataStore.items.Where(ord => ord.ZamowienieId == ZamowienieId);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            await ExecuteLoadItemsCommand();
            IsBusy = false;
        }
        private async void OnAddItem(object obj)
            => await GoToAddPage();

        public async Task GoToDetailsPage(ZamowioneProduktyForView item)
        {
            if (item == null) return;
            string route = $"{nameof(ZamowioneProduktyDetailPage)}?ZamowienieId={item.ZamowienieId}&ProduktId={item.ProduktId}";
            await Shell.Current.GoToAsync(route);
        }

        async void OnItemSelected(ZamowioneProduktyForView item)
        {
            if (item == null)
                return;
            await GoToDetailsPage(item);
        }

        public List<ZamowienieForView> AllItems { get; set; } = new List<ZamowienieForView>();

        public async Task GoToAddPage()
        {
            await Shell.Current.GoToAsync($"{nameof(NewZamowioneProduktyPage)}?ZamowienieId={ZamowienieId}");
        }

        protected override async Task GoToUpdatePage()
            => await Shell.Current.GoToAsync($"{nameof(EditZamowieniePage)}?{nameof(EditZamowienieViewModel.ItemId)}={zamowienieId}");

        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                if (item != null)
                {
                    this.CopyProperties(item);
                    UpdateSelectedKlient(item.KlientId);
                    await ExecuteLoadItemsCommand();
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private void UpdateSelectedKlient(int? klientId)
        {
            SelectedKlient = Klienci?.Find(k => k.KlientId == klientId) ?? new KlientForView { Nazwisko = "Brak danych" };
        }
    }
}
