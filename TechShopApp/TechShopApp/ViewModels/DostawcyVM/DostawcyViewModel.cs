using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.Views;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.DostawcyVM
{
    public class DostawcyViewModel : AItemListViewModel<KlientForView>
    {
        public string KlienciCountText
        {
            get
            {
                int count = Items?.Count ?? 0;
                string koncowka = count == 1 ? "klienta" : "klientów";
                return $"Znaleziono {count} {koncowka}";
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    FilterItems();
                }
            }
        }

        public List<KlientForView> AllItems { get; set; } = new List<KlientForView>();

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = (await DataStore.GetItemsAsync(true)).ToList();
                AllItems = items;
                foreach (var item in items)
                    Items.Add(item);

                OnPropertyChanged(nameof(KlienciCountText));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public DostawcyViewModel() : base("Klient") { }

        public async override Task GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewKlientPage));
        }

        public async override Task GoToDetailsPage(KlientForView item)
        {
            await Shell.Current.GoToAsync($"{nameof(KlientDetailPage)}?{nameof(DostawcyDetailViewModel.ItemId)}={item.KlientId}");
        }

        private void FilterItems()
        {
            var search = SearchText?.Trim().ToLower() ?? "";

            var filtered = string.IsNullOrWhiteSpace(search)
                ? AllItems
                : AllItems.Where(p =>
                    (p.Imie?.ToLower().Contains(search) ?? false) ||
                    (p.Nazwisko?.ToLower().Contains(search) ?? false) ||
                    (p.Email?.ToLower().Contains(search) ?? false) ||
                    (p.Telefon?.ToLower().Contains(search) ?? false) ||
                    (p.Adres?.ToLower().Contains(search) ?? false)
                ).ToList();

            Items.Clear();
            foreach (var item in filtered)
                Items.Add(item);

            OnPropertyChanged(nameof(KlienciCountText));
        }
    }
}
