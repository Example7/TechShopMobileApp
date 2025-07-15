using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestApi.Helpers;
using RestApi.Models;

namespace RestApi.ForView
{
    public class DostawcyForView
    {
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

        public static implicit operator Dostawcy(DostawcyForView cli)
            => new Dostawcy().CopyProperties(cli);
        public static implicit operator DostawcyForView(Dostawcy cli)
            => new DostawcyForView().CopyProperties(cli);
    }
}
