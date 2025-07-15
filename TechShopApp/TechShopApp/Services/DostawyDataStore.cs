using System.Linq;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using Xamarin.Forms;

namespace TechShopApp.Services
{
    public class DostawyDataStore : AListDataStore<DostawyForView>
    {
        public DostawyDataStore()
            => items = DependencyService.Get<TechShopService>().DostawyAllAsync().GetAwaiter().GetResult().ToList();

        public async override Task<bool> AddItemToService(DostawyForView item)
        {
            return await DependencyService.Get<TechShopService>().DostawyPOSTAsync(item).HandleRequest();
        }

        public async override Task<bool> DeleteItemFromService(DostawyForView item)
        {
            return await DependencyService.Get<TechShopService>().DostawyDELETEAsync(item.DostawaId).HandleRequest();
        }

        public override DostawyForView Find(DostawyForView item)
        {
            return items.Where((DostawyForView arg) => arg.DostawaId == item.DostawaId).FirstOrDefault();
        }

        public override DostawyForView Find(int id)
        {
            return items.FirstOrDefault(s => s.DostawaId == id);
        }

        public override async Task Refresh()
            => items = (await DependencyService.Get<TechShopService>().DostawyAllAsync()).ToList();

        public async override Task<bool> UpdateItemInService(DostawyForView item)
        {
            return await DependencyService.Get<TechShopService>().DostawyPUTAsync(item.DostawaId, item).HandleRequest();
        }
    }
}
