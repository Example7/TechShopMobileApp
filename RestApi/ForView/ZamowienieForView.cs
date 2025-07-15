using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestApi.Helpers;
using RestApi.Models;

namespace RestApi.ForView
{
    public class ZamowienieForView
    {
        [Key]
        [Column("ZamowienieID")]
        public int ZamowienieId { get; set; }
        [Column("KlientID")]
        public int? KlientId { get; set; }
        public string? KlientData { get; set; } = default!;
        [Column(TypeName = "datetime")]
        public DateTime DataZamowienia { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Status { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Kwota { get; set; }

        public static implicit operator Zamowienia(ZamowienieForView cli)
            => new Zamowienia().CopyProperties(cli);
        public static implicit operator ZamowienieForView(Zamowienia cli)
            => new ZamowienieForView() { KlientData = cli?.Klient?.Nazwisko??string.Empty }.CopyProperties(cli);
    }
}
