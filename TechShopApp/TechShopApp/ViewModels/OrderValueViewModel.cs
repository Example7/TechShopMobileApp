using System;
using System.Collections.ObjectModel;
using System.Globalization;
using TechShopApp.ServiceReference;
using TechShopApp.Services;
using TechShopApp.ViewModels.Abstract;
using Xamarin.Forms;

namespace TechShopApp.ViewModels
{
    public class OrderValueViewModel : BaseViewModel
    {
        private KlientForView selectedKlient;
        private DateTime? date = DateTime.Now;
        private double totalOrderValueOfClientByStatus;
        private int orderCountByClient;

        private KlientDataStore klientDataStore;

        public OrderValueViewModel()
        {
            Klienci = new ObservableCollection<KlientForView>();

            klientDataStore = DependencyService.Get<KlientDataStore>();

            LoadKlienciAsync();

            GetTotalOrderValueOfClientByStatusCommand = new Command(OnGetTotalOrderValueOfClientByStatus);
            GetOrderCountByClientCommand = new Command(OnGetOrderCountByClient);
            RefreshCommand = new Command(OnRefresh);
        }

        public ObservableCollection<KlientForView> Klienci { get; }

        public KlientForView SelectedKlient
        {
            get => selectedKlient;
            set => SetProperty(ref selectedKlient, value);
        }

        public DateTime? Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public double TotalOrderValueOfClientByStatus
        {
            get => totalOrderValueOfClientByStatus;
            set
            {
                if (SetProperty(ref totalOrderValueOfClientByStatus, value))
                {
                    OnPropertyChanged(nameof(TotalOrderValueOfClientByStatusPLN));
                }
            }
        }

        public string TotalOrderValueOfClientByStatusPLN =>
            TotalOrderValueOfClientByStatus.ToString("C", new CultureInfo("pl-PL"));

        public int OrderCountByClient
        {
            get => orderCountByClient;
            set => SetProperty(ref orderCountByClient, value);
        }

        public Command GetTotalOrderValueOfClientByStatusCommand { get; }
        public Command GetOrderCountByClientCommand { get; }
        public Command RefreshCommand { get; }

        private async void LoadKlienciAsync()
        {
            await klientDataStore.Refresh();

            Klienci.Clear();
            foreach (var klient in klientDataStore.Items)
            {
                Klienci.Add(klient);
            }
        }

        private void OnRefresh()
        {
            LoadKlienciAsync();

            TotalOrderValueOfClientByStatus = 0;
            OrderCountByClient = 0;
            SelectedKlient = null;
        }

        private void OnGetTotalOrderValueOfClientByStatus()
        {
            if (SelectedKlient != null)
            {
                var result = DependencyService.Get<OrderValueDataStore>()
                    .GetTotalOrderValueOfClientByStatus(SelectedKlient.KlientId, "Zrealizowane");
                TotalOrderValueOfClientByStatus = result;
            }
        }

        private void OnGetOrderCountByClient()
        {
            if (SelectedKlient != null)
            {
                var result = DependencyService.Get<OrderValueDataStore>()
                    .GetOrderCountByClient(SelectedKlient.KlientId);
                OrderCountByClient = result;
            }
        }
    }
}
