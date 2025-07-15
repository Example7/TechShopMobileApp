using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    [Table("Kategorie")]
    public partial class Kategorie
    {
        public Kategorie()
        {
            Produkty = new HashSet<Produkty>();
        }

        [Key]
        [Column("KategoriaID")]
        public int KategoriaId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Nazwa { get; set; } = null!;
        [Column(TypeName = "text")]
        public string? Opis { get; set; }

        [InverseProperty("Kategorie")]
        public virtual ICollection<Produkty> Produkty { get; set; }
    }
}
