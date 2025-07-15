using System.Linq;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using Xamarin.Forms;

namespace TechShopApp.Services
{
    public class ZamowienieDataStore : AListDataStore<ZamowienieForView>
    {
        public async override Task<bool> AddItemToService(ZamowienieForView item)
        { 
            return await DependencyService.Get<TechShopService>().ZamowieniaPOSTAsync(item).HandleRequest(); 
        }

        public async override Task<bool> DeleteItemFromService(ZamowienieForView item)
        {
            return await DependencyService.Get<TechShopService>().ZamowieniaDELETEAsync(item.ZamowienieId).HandleRequest();
        }

        public override ZamowienieForView Find(ZamowienieForView item)
        {
            return items.Where((ZamowienieForView arg) => arg.ZamowienieId == item.ZamowienieId).FirstOrDefault();
        }

        public override ZamowienieForView Find(int id)
        {
            return items.FirstOrDefault(s => s.ZamowienieId == id);
        }

        public override async Task Refresh()
            => items = (await DependencyService.Get<TechShopService>().ZamowieniaAllAsync()).ToList();

        public async override Task<bool> UpdateItemInService(ZamowienieForView item)
        {
            return await DependencyService.Get<TechShopService>().ZamowieniaPUTAsync(item.ZamowienieId, item).HandleRequest();
        }
    }
}
