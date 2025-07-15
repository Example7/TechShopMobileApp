using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using Xamarin.Forms;

namespace TechShopApp.Services
{
    public class KlientDataStore : AListDataStore<KlientForView>
    {
        public KlientDataStore()
            => items = DependencyService.Get<TechShopService>().KlienciAllAsync().GetAwaiter().GetResult().ToList();

        public List<KlientForView> Items => items;

        public override async Task<bool> AddItemToService(KlientForView item)
        {
            return await DependencyService.Get<TechShopService>().KlienciPOSTAsync(item).HandleRequest();
        }

        public override async Task<bool> DeleteItemFromService(KlientForView item)
        {
            return await DependencyService.Get<TechShopService>().KlienciDELETEAsync(item.KlientId).HandleRequest();
        }

        public override KlientForView Find(KlientForView item)
        {
            return items.Where((KlientForView arg) => arg.KlientId == item.KlientId).FirstOrDefault();
        }

        public override KlientForView Find(int id)
        {
            return items.FirstOrDefault(s => s.KlientId == id);
        }

        public override async Task Refresh()
            => items = (await DependencyService.Get<TechShopService>().KlienciAllAsync()).ToList();

        public override async Task<bool> UpdateItemInService(KlientForView item)
        {
            return await DependencyService.Get<TechShopService>().KlienciPUTAsync(item.KlientId, item).HandleRequest();
        }
    }
}
