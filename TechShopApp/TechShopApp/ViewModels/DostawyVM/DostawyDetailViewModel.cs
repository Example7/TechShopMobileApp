using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TechShopApp.Helpers;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.Views.DostawyView;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.DostawyVM
{
    public class DostawyDetailViewModel : AItemDetailsViewModel<DostawyForView>
    {
        #region Fields
        private int dostawaId;
        private int? dostawcaId;
        private DateTime dataDostawy;
        private string statusDostawy;
        private DostawcyForView selectedDostawca;
        private List<DostawcyForView> dostawcy;
        #endregion
        #region Properties
        public int DostawaId
        {
            get => dostawaId;
            set => SetProperty(ref dostawaId, value);
        }
        public int? DostawcaId
        {
            get => dostawcaId;
            set => SetProperty(ref dostawcaId, value);
        }
        public DateTime DataDostawy
        {
            get => dataDostawy;
            set => SetProperty(ref dataDostawy, value);
        }
        public string StatusDostawy
        {
            get => statusDostawy;
            set => SetProperty(ref statusDostawy, value);
        }
        public List<DostawcyForView> Dostawcy
        {
            get
            {
                return dostawcy;
            }
        }
        public DostawcyForView SelectedDostawca
        {
            get => selectedDostawca;
            set => SetProperty(ref selectedDostawca, value);
        }
        #endregion
        public DostawyDetailViewModel()
            : base("Opis Dostawcy")
        {
            selectedDostawca = new DostawcyForView();
            dostawcy = DependencyService.Get<AListDataStore<DostawcyForView>>().items;
        }
        protected override async Task GoToUpdatePage()
            => await Shell.Current.GoToAsync($"{nameof(EditDostawyPage)}?{nameof(EditDostawyViewModel.ItemId)}={DostawaId}");

        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                if (item != null)
                {
                    this.CopyProperties(item);
                    DataDostawy = item.DataDostawy.DateTime;
                    UpdateSelectedDostawca(item.DostawcaId);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private void UpdateSelectedDostawca(int? dostawcaId)
        {
            SelectedDostawca = Dostawcy?.Find(d => d.DostawcaId == dostawcaId) ?? new DostawcyForView { Nazwa = "Brak danych" };
        }
    }
}
