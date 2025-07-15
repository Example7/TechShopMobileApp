using System.Threading.Tasks;
using TechShopApp.ServiceReference;

namespace TechShopApp.Services
{
    public interface IZamowioneProduktyDataStore : IDataStore<ZamowioneProduktyForView>
    {
        Task<ZamowioneProduktyForView> GetItemAsync(int zamowienieId, int produktId);
        Task<bool> DeleteItemAsync(int zamowienieId, int produktId);
    }

}
