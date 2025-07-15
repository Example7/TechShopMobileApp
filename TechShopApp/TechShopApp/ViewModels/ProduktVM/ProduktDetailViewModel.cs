using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TechShopApp.ServiceReference;
using TechShopApp.Services.Abstract;
using TechShopApp.ViewModels.Abstract;
using TechShopApp.Views;
using Xamarin.Forms;

namespace TechShopApp.ViewModels.ItemVM
{
    public class ProduktDetailViewModel : AItemDetailsViewModel<ProduktForView>
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
            set => SetProperty(ref stanMagazynu, value);
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
        public ProduktDetailViewModel() : base("Opis produktu") 
        {
            selectedKategoria = new KategorieForView();
            listaKategorii = DependencyService.Get<AListDataStore<KategorieForView>>().items;
        }

        protected override async Task GoToUpdatePage()
        => await Shell.Current.GoToAsync($"{nameof(EditProduktPage)}?{nameof(EditProduktViewModel.ItemId)}={Id}");

        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                if (item != null)
                {
                    Id = item.ProduktId;
                    Nazwa = item.Nazwa;
                    Opis = item.Opis;
                    Cena = (decimal)item.Cena;
                    StanMagazynu = item.StanMagazynowy;
                    KategoriaId = item.KategoriaId;

                    UpdateSelectedKategoria(item.KategoriaId);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private void UpdateSelectedKategoria(int? Id)
        {
            SelectedKategoria = ListaKategorii?.Find(d => d.KategoriaId == Id) ?? new KategorieForView { Nazwa = "Brak danych" };
        }
    }
}
