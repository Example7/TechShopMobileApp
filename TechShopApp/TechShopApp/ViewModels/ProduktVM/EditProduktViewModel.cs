using System.Diagnostics;
using System;
using TechShopApp.ViewModels.Abstract;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using System.Collections.Generic;
using System.Linq;
using TechShopApp.Services.Abstract;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ItemVM
{
    public class EditProduktViewModel : AItemUpdateViewModel<ProduktForView>
    {
        #region Fields
        private int id;
        private string nazwa;
        private string opis;
        private decimal cena;
        private int stanMagazynu;
        private int? kategoriaId;
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
            set => SetProperty(ref  stanMagazynu, value);
        }
        public int? KategoriaId
        {
            get => kategoriaId;
            set => SetProperty(ref kategoriaId, value);
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
        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                Id = item.ProduktId;
                Nazwa = item.Nazwa;
                Opis = item.Opis;
                Cena = (decimal)item.Cena;
                StanMagazynu = item.StanMagazynowy;
                KategoriaId = item.KategoriaId;
                SelectedKategoria = ListaKategorii.FirstOrDefault(d => d.KategoriaId == item.KategoriaId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public override bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(Nazwa)
                && Cena > 0
                && StanMagazynu >= 0;
        }
        public EditProduktViewModel()
            : base("Edycja Produktu")
        {
            selectedKategoria = new KategorieForView();
            listaKategorii = DependencyService.Get<AListDataStore<KategorieForView>>().items;
        }
        public override ProduktForView SetItem()
            => new ProduktForView()
            {
                ProduktId = this.Id,
                Nazwa = this.Nazwa,
                Opis = this.Opis,
                Cena = (double)this.Cena,
                StanMagazynowy = this.StanMagazynu,
                KategoriaId = this.SelectedKategoria?.KategoriaId ?? 0,
            };
    }
}
