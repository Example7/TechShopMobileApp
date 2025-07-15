using System.Linq;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using Xamarin.Forms;

namespace TechShopApp.Services
{
    public class KategorieDataStore : AListDataStore<KategorieForView>
    {
        public KategorieDataStore()
            => items = DependencyService.Get<TechShopService>().KategorieAllAsync().GetAwaiter().GetResult().ToList();

        public async override Task<bool> AddItemToService(KategorieForView item)
        {
            return await DependencyService.Get<TechShopService>().KategoriePOSTAsync(item).HandleRequest();
        }

        public async override Task<bool> DeleteItemFromService(KategorieForView item)
        {
            return await DependencyService.Get<TechShopService>().DostawyDELETEAsync(item.KategoriaId).HandleRequest();
        }

        public override KategorieForView Find(KategorieForView item)
        {
            return items.Where((KategorieForView arg) => arg.KategoriaId == item.KategoriaId).FirstOrDefault();
        }

        public override KategorieForView Find(int id)
        {
            return items.FirstOrDefault(s => s.KategoriaId == id);
        }

        public override async Task Refresh()
            => items = (await DependencyService.Get<TechShopService>().KategorieAllAsync()).ToList();

        public async override Task<bool> UpdateItemInService(KategorieForView item)
        {
            return await DependencyService.Get<TechShopService>().KategoriePUTAsync(item.KategoriaId, item).HandleRequest();
        }
    }
}
