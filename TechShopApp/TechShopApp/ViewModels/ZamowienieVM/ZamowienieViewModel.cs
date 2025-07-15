using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.Views.ZamowienieView;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ZamowienieVM
{
    public class ZamowienieViewModel : AItemListViewModel<ZamowienieForView>
    {
        private string _searchText;

        public ZamowienieViewModel() : base("Zamówienie") { }

        public List<ZamowienieForView> AllItems { get; set; } = new List<ZamowienieForView>();

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

                OnPropertyChanged(nameof(ZamowieniaCountText));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async override Task GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewZamowieniePage));
        }

        public async override Task GoToDetailsPage(ZamowienieForView item)
        {
            await Shell.Current.GoToAsync($"{nameof(ZamowienieDetailPage)}?{nameof(ZamowienieDetailViewModel.ItemId)}={item.ZamowienieId}");
        }

        public string ZamowieniaCountText
        {
            get
            {
                int count = Items?.Count ?? 0;
                string koncowka;

                if (count == 0)
                    koncowka = "zamówień";
                else if (count == 1)
                    koncowka = "zamówienie";
                else if (count % 10 >= 2 && count % 10 <= 4 && (count % 100 < 10 || count % 100 >= 20))
                    koncowka = "zamówienia";
                else
                    koncowka = "zamówień";

                return $"Znaleziono {count} {koncowka}";
            }
        }

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

        private void FilterItems()
        {
            var search = SearchText?.Trim().ToLower() ?? "";

            var filtered = string.IsNullOrWhiteSpace(search)
                ? AllItems
                : AllItems.Where(p =>
                    p.ZamowienieId.ToString().Contains(search) ||
                    (p.KlientId.HasValue && p.KlientId.Value.ToString().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(p.KlientData) && p.KlientData.ToLower().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(p.Status) && p.Status.ToLower().Contains(search)) ||
                    p.Kwota.ToString("F2").Contains(search) ||
                    (p.DataZamowienia != default && p.DataZamowienia.ToString("yyyy-MM-dd").Contains(search))
                ).ToList();

            Items.Clear();
            foreach (var item in filtered)
                Items.Add(item);

            OnPropertyChanged(nameof(ZamowieniaCountText));
        }

    }
}
