using System.Linq;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using Xamarin.Forms;

namespace TechShopApp.Services
{
    public class DostawcyDataStore : AListDataStore<DostawcyForView>
    {
        public DostawcyDataStore()
            => items = DependencyService.Get<TechShopService>().DostawcyAllAsync().GetAwaiter().GetResult().ToList();

        public async override Task<bool> AddItemToService(DostawcyForView item)
        {
            return await DependencyService.Get<TechShopService>().DostawcyPOSTAsync(item).HandleRequest();
        }

        public async override Task<bool> DeleteItemFromService(DostawcyForView item)
        {
            return await DependencyService.Get<TechShopService>().DostawcyDELETEAsync(item.DostawcaId).HandleRequest();
        }

        public override DostawcyForView Find(DostawcyForView item)
        {
            return items.Where((DostawcyForView arg) => arg.DostawcaId == item.DostawcaId).FirstOrDefault();
        }

        public override DostawcyForView Find(int id)
        {
            return items.FirstOrDefault(s => s.DostawcaId == id);
        }

        public override async Task Refresh()
            => items = (await DependencyService.Get<TechShopService>().DostawcyAllAsync()).ToList();

        public async override Task<bool> UpdateItemInService(DostawcyForView item)
        {
            return await DependencyService.Get<TechShopService>().DostawcyPUTAsync(item.DostawcaId, item).HandleRequest();
        }
    }
}
