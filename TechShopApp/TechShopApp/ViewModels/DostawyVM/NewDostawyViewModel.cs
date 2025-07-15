using System;
using System.Collections.Generic;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.DostawyVM
{
    public class NewDostawyViewModel : ANewItemViewModel<DostawyForView>
    {
        #region Fields
        private DateTime dataDostawy;
        private string statusDostawy;
        private DostawcyForView selectedDostawca;
        private List<DostawcyForView> dostawcy;
        #endregion
        #region Properties
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

        public override bool ValidateSave()
        {
            return DataDostawy >= DateTime.Now
                && selectedDostawca.DostawcaId > 0;
        }

        public NewDostawyViewModel() : base("Dodaj dostawe") 
        {
            DataDostawy = DateTime.UtcNow.Date;
            selectedDostawca = new DostawcyForView();
            dostawcy = DependencyService.Get<AListDataStore<DostawcyForView>>().items;
        }

        public override DostawyForView SetItem()
        {
            return new DostawyForView
            {
                DostawcaId = this.SelectedDostawca?.DostawcaId ?? 0,
                DataDostawy = this.DataDostawy,
                StatusDostawy = this.StatusDostawy
            };
        }
    }
}
