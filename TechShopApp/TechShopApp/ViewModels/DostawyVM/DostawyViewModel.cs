using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.Views.DostawyView;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.DostawyVM
{
    public class DostawyViewModel : AItemListViewModel<DostawyForView>
    {
        public string DostawyCountText
        {
            get
            {
                int count = Items?.Count ?? 0;
                string koncowka;

                if (count == 0)
                    koncowka = "dostaw";
                else if (count == 1)
                    koncowka = "dostawę";
                else if (count % 10 >= 2 && count % 10 <= 4 && (count % 100 < 10 || count % 100 >= 20))
                    koncowka = "dostawy";
                else
                    koncowka = "dostaw";

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

        public List<DostawyForView> AllItems { get; set; } = new List<DostawyForView>();

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

                OnPropertyChanged(nameof(DostawyCountText));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public DostawyViewModel() : base("Dostawy") { }

        public async override Task GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewDostawyPage));
        }

        public async override Task GoToDetailsPage(DostawyForView item)
        {
            await Shell.Current.GoToAsync($"{nameof(DostawyDetailPage)}?{nameof(DostawyDetailViewModel.ItemId)}={item.DostawaId}");
        }

        private void FilterItems()
        {
            var search = SearchText?.Trim().ToLower() ?? "";

            var filtered = string.IsNullOrWhiteSpace(search)
                ? AllItems
                : AllItems.Where(p =>
                    p.DostawaId.ToString().Contains(search) ||
                    (p.DostawcaId.HasValue && p.DostawcaId.Value.ToString().Contains(search)) ||
                    p.DataDostawy.ToString("yyyy-MM-dd").ToLower().Contains(search) ||
                    (p.StatusDostawy?.ToLower().Contains(search) ?? false)
                ).ToList();

            Items.Clear();
            foreach (var item in filtered)
                Items.Add(item);

            OnPropertyChanged(nameof(DostawyCountText));
        }
    }
}
