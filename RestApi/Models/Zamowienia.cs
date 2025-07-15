using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    public partial class Zamowienia
    {
        public Zamowienia()
        {
            ZamowioneProdukty = new HashSet<ZamowioneProdukty>();
        }

        [Key]
        [Column("ZamowienieID")]
        public int ZamowienieId { get; set; }
        [Column("KlientID")]
        public int? KlientId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataZamowienia { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Status { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Kwota { get; set; }

        [ForeignKey("KlientId")]
        [InverseProperty("Zamowienia")]
        public virtual Klienci? Klient { get; set; }
        [InverseProperty("Zamowienie")]
        public virtual ICollection<ZamowioneProdukty> ZamowioneProdukty { get; set; }
    }
}
