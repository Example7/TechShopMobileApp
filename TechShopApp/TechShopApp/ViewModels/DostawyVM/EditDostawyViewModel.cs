using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.DostawyVM
{
    public class EditDostawyViewModel : AItemUpdateViewModel<DostawyForView>
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
        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                if (item != null)
                {
                    DostawaId = item.DostawaId;
                    DostawcaId = item.DostawcaId;
                    DataDostawy = item.DataDostawy.DateTime;
                    StatusDostawy = item.StatusDostawy;
                    SelectedDostawca = Dostawcy.FirstOrDefault(d => d.DostawcaId == item.DostawcaId);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public override bool ValidateSave()
        {
            return DostawcaId.HasValue;
        }
        public EditDostawyViewModel()
            : base("Edycja dostawy!")
        {
            DataDostawy = DateTime.UtcNow.Date;
            selectedDostawca = new DostawcyForView();
            dostawcy = DependencyService.Get<AListDataStore<DostawcyForView>>().items;
        }
        public override DostawyForView SetItem()
        {
            return new DostawyForView
            {
                DostawaId = this.DostawaId,
                DostawcaId = this.SelectedDostawca?.DostawcaId ?? 0,
                DataDostawy = this.DataDostawy,
                StatusDostawy = this.StatusDostawy
            };
        }
    }
}
