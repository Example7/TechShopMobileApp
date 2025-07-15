using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestApi.Models;
using RestApi.Helpers;

namespace RestApi.ForView
{
    public class KlientForView
    {
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

        public static implicit operator Klienci(KlientForView cli)
            => new Klienci().CopyProperties(cli);
        public static implicit operator KlientForView(Klienci cli)
            => new KlientForView().CopyProperties(cli);
    }
}
