using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    [Table("Dostawy")]
    public partial class Dostawy
    {
        public Dostawy()
        {
            ProduktDostawy = new HashSet<ProduktDostawy>();
        }

        [Key]
        [Column("DostawaID")]
        public int DostawaId { get; set; }
        [Column("DostawcaID")]
        public int? DostawcaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataDostawy { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? StatusDostawy { get; set; }

        [ForeignKey("DostawcaId")]
        [InverseProperty("Dostawy")]
        public virtual Dostawcy? Dostawca { get; set; }
        [InverseProperty("Dostawa")]
        public virtual ICollection<ProduktDostawy> ProduktDostawy { get; set; }
    }
}
