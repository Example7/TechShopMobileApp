using System.Threading.Tasks;
using System;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using Xamarin.Forms;
using TechShopApp.Helpers;
using System.Linq;
using TechShopApp.Services;
using System.Diagnostics;

public class ZamowioneProduktyDataStore : AListDataStore<ZamowioneProduktyForView>, IZamowioneProduktyDataStore
{
    public ZamowioneProduktyDataStore()
        => items = DependencyService.Get<TechShopService>().ZamowioneProduktyAllAsync().GetAwaiter().GetResult().ToList();

    public override async Task<bool> AddItemToService(ZamowioneProduktyForView item)
    {
        return await DependencyService.Get<TechShopService>().ZamowioneProduktyPOSTAsync(item).HandleRequest();
    }

    public override async Task<bool> DeleteItemFromService(ZamowioneProduktyForView item)
    {
        return await DeleteItemAsync(item.ZamowienieId, item.ProduktId);
    }

    public override ZamowioneProduktyForView Find(ZamowioneProduktyForView item)
    {
        return items.FirstOrDefault(arg =>
            arg.ZamowienieId == item.ZamowienieId &&
            arg.ProduktId == item.ProduktId);
    }

    public override ZamowioneProduktyForView Find(int id)
    {
        throw new NotImplementedException("ZamowioneProdukty nie mają pojedynczego ID – użyj Find(item) z composite key.");
    }

    public override async Task Refresh()
    {
        items = (await DependencyService.Get<TechShopService>().ZamowioneProduktyAllAsync()).ToList();
    }

    public override async Task<bool> UpdateItemInService(ZamowioneProduktyForView item)
    {
        return await DependencyService.Get<TechShopService>().ZamowioneProduktyPUTAsync(item.ZamowienieId, item.ProduktId, item).HandleRequest();
    }

    public Task<ZamowioneProduktyForView> GetItemAsync(int zamowienieId, int produktId)
    {
        return DependencyService.Get<TechShopService>().ZamowioneProduktyGETAsync(zamowienieId, produktId);
    }

    public async Task<bool> DeleteItemAsync(int zamowienieId, int produktId)
    {
        try
        {
            await DependencyService.Get<TechShopService>().ZamowioneProduktyDELETEAsync(zamowienieId, produktId);

            var itemToRemove = items.FirstOrDefault(x => x.ZamowienieId == zamowienieId && x.ProduktId == produktId);
            if (itemToRemove != null)
                items.Remove(itemToRemove);

            await Refresh();

            return true;
        }
        catch (TechShopApp.ServiceReference.ApiException ex)
        {
            if ((System.Net.HttpStatusCode)ex.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                var itemToRemove = items.FirstOrDefault(x => x.ZamowienieId == zamowienieId && x.ProduktId == produktId);
                if (itemToRemove != null)
                    items.Remove(itemToRemove);

                await Refresh();

                return true;
            }
            Debug.WriteLine($"Błąd usuwania: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Błąd usuwania: {ex.Message}");
            return false;
        }
    }

}
