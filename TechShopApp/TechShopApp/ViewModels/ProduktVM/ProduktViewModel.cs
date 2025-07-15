using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.ViewModels.ItemVM;
using TechShopApp.Views;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ProduktVM
{
    public class ProduktViewModel : AItemListViewModel<ProduktForView>
    {
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

        public List<ProduktForView> AllItems { get; set; } = new List<ProduktForView>();

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
            }
            finally
            {
                IsBusy = false;
            }
        }
        public ProduktViewModel() : base("Produkty") 
        {
        }

        public override async Task GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewProduktPage));
        }
        public override async Task GoToDetailsPage(ProduktForView item)
        {
            await Shell.Current.GoToAsync($"{nameof(ProduktDetailPage)}?{nameof(ProduktDetailViewModel.ItemId)}={item.ProduktId}");
        }

        private void FilterItems()
        {
            var filtered = string.IsNullOrWhiteSpace(SearchText)
                ? AllItems
                : AllItems.Where(p => p.Nazwa.ToLower().Contains(SearchText.ToLower())).ToList();

            Items.Clear();
            foreach (var item in filtered)
                Items.Add(item);
        }
    }
}