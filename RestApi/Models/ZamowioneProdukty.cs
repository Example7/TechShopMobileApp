using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    [Table("ZamowioneProdukty")]
    public partial class ZamowioneProdukty
    {
        [Key]
        [Column("ZamowienieID")]
        public int ZamowienieId { get; set; }
        [Key]
        [Column("ProduktID")]
        public int ProduktId { get; set; }
        public int Ilosc { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double CenaJednostkowa { get; set; }

        [ForeignKey("ProduktId")]
        [InverseProperty("ZamowioneProdukty")]
        public virtual Produkty Produkt { get; set; } = null!;
        [ForeignKey("ZamowienieId")]
        [InverseProperty("ZamowioneProdukty")]
        public virtual Zamowienia Zamowienie { get; set; } = null!;
    }
}
