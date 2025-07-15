using TechShopApp.ServiceReference;
using Xamarin.Forms;

namespace TechShopApp.Services
{
    public class OrderValueDataStore
    {
        public double GetTotalOrderValueOfClientByStatus(int clientId, string status)
        {
            return DependencyService.Get<TechShopService>()
                .TotalOrderValueOfClientByStatusAsync(clientId, status)
                .GetAwaiter()
                .GetResult();
        }

        public int GetOrderCountByClient(int clientId)
        {
            return DependencyService.Get<TechShopService>()
                .OrderCountByClientAsync(clientId)
                .GetAwaiter()
                .GetResult();
        }
    }
}
