using System.Linq;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using Xamarin.Forms;

namespace TechShopApp.Services
{
    public class ProduktDataStore : AListDataStore<ProduktForView>
    {
        public ProduktDataStore()
            => items = DependencyService.Get<TechShopService>().ProduktyAllAsync().GetAwaiter().GetResult().ToList();

        public override async Task<bool> AddItemToService(ProduktForView item)
        {
            return await DependencyService.Get<TechShopService>().ProduktyPOSTAsync(item).HandleRequest();
        }

        public override async Task<bool> DeleteItemFromService(ProduktForView item)
        {
            return await DependencyService.Get<TechShopService>().ProduktyDELETEAsync(item.ProduktId).HandleRequest();
        }

        public override ProduktForView Find(ProduktForView item)
        {
            return items.Where((ProduktForView arg) => arg.ProduktId == item.ProduktId).FirstOrDefault();
        }

        public override ProduktForView Find(int id)
        {
            return items.FirstOrDefault(s => s.ProduktId == id);
        }

        public override async Task Refresh()
            => items = (await DependencyService.Get<TechShopService>().ProduktyAllAsync()).ToList();

        public override async Task<bool> UpdateItemInService(ProduktForView item)
        {
            return await DependencyService.Get<TechShopService>().ProduktyPUTAsync(item.ProduktId, item).HandleRequest();
        }
    }
}