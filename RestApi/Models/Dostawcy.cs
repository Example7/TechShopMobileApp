using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    [Table("Dostawcy")]
    public partial class Dostawcy
    {
        public Dostawcy()
        {
            Dostawy = new HashSet<Dostawy>();
        }

        [Key]
        [Column("DostawcaID")]
        public int DostawcaId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Nazwa { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string? Telefon { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? Email { get; set; }
        [Column(TypeName = "text")]
        public string? Adres { get; set; }

        [InverseProperty("Dostawca")]
        public virtual ICollection<Dostawy> Dostawy { get; set; }
    }
}
