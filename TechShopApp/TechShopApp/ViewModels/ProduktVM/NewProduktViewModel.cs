using System.Collections.Generic;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ItemVM
{
    public class NewProduktViewModel : ANewItemViewModel<ProduktForView>
    {
        #region Fields
        private int id;
        private string nazwa;
        private string opis;
        private decimal cena;
        private int stanMagazynu;
        private KategorieForView selectedKategoria;
        private List<KategorieForView> listaKategorii;
        #endregion
        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string Nazwa
        {
            get => nazwa;
            set => SetProperty(ref nazwa, value);
        }
        public string Opis
        {
            get => opis;
            set => SetProperty(ref opis, value);
        }
        public decimal Cena
        {
            get => cena;
            set => SetProperty(ref cena, value);
        }
        public int StanMagazynu
        {
            get => stanMagazynu;
            set => SetProperty(ref stanMagazynu, value);
        }
        public List<KategorieForView> ListaKategorii
        {
            get
            {
                return listaKategorii;
            }
        }
        public KategorieForView SelectedKategoria
        {
            get => selectedKategoria;
            set => SetProperty(ref selectedKategoria, value);
        }
        #endregion
        public NewProduktViewModel() : base("Dodaj produkt") 
        {
            selectedKategoria = new KategorieForView();
            listaKategorii = DependencyService.Get<AListDataStore<KategorieForView>>().items;
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(Nazwa)
                && Cena > 0
                && StanMagazynu >= 0;
        }

        public override ProduktForView SetItem()
            => new ProduktForView()
            {
                Nazwa = this.Nazwa,
                Opis = this.Opis,
                Cena = (double)this.Cena,
                StanMagazynowy = this.StanMagazynu,
                KategoriaId = this.SelectedKategoria?.KategoriaId ?? 0,
            };
    }
}
