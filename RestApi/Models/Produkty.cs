using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    [Table("Produkty")]
    public partial class Produkty
    {
        public Produkty()
        {
            ProduktDostawy = new HashSet<ProduktDostawy>();
            ZamowioneProdukty = new HashSet<ZamowioneProdukty>();
        }

        [Key]
        [Column("ProduktID")]
        public int ProduktId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Nazwa { get; set; } = null!;
        [Column(TypeName = "text")]
        public string? Opis { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cena { get; set; }
        public int StanMagazynowy { get; set; }
        [Column("KategoriaID")]
        public int? KategoriaId { get; set; }

        [ForeignKey("KategoriaId")]
        [InverseProperty("Produkty")]
        public virtual Kategorie? Kategorie { get; set; }
        [InverseProperty("Produkt")]
        public virtual ICollection<ProduktDostawy> ProduktDostawy { get; set; }
        [InverseProperty("Produkt")]
        public virtual ICollection<ZamowioneProdukty> ZamowioneProdukty { get; set; }
    }
}
