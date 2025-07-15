using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    [Table("Klienci")]
    [Index("Email", Name = "UQ__Klienci__A9D10534687AB9C2", IsUnique = true)]
    public partial class Klienci
    {
        public Klienci()
        {
            Zamowienia = new HashSet<Zamowienia>();
        }

        [Key]
        [Column("KlientID")]
        public int KlientId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Imie { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Nazwisko { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string? Telefon { get; set; }
        [Column(TypeName = "text")]
        public string? Adres { get; set; }

        [InverseProperty("Klient")]
        public virtual ICollection<Zamowienia> Zamowienia { get; set; }
    }
}
