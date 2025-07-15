using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestApi.Models;
using RestApi.Helpers;

namespace RestApi.ForView
{
    public class KategorieForView
    {
        [Key]
        [Column("KategoriaID")]
        public int KategoriaId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Nazwa { get; set; } = null!;
        [Column(TypeName = "text")]
        public string? Opis { get; set; }

        public static implicit operator Kategorie(KategorieForView cli)
            => new Kategorie().CopyProperties(cli);
        public static implicit operator KategorieForView(Kategorie cli)
            => new KategorieForView().CopyProperties(cli);
    }
}
