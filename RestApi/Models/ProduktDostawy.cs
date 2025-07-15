using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    [Table("ProduktDostawy")]
    public partial class ProduktDostawy
    {
        [Key]
        [Column("DostawaID")]
        public int DostawaId { get; set; }
        [Key]
        [Column("ProduktID")]
        public int ProduktId { get; set; }
        public int Ilosc { get; set; }

        [ForeignKey("DostawaId")]
        [InverseProperty("ProduktDostawy")]
        public virtual Dostawy Dostawa { get; set; } = null!;
        [ForeignKey("ProduktId")]
        [InverseProperty("ProduktDostawy")]
        public virtual Produkty Produkt { get; set; } = null!;
    }
}
