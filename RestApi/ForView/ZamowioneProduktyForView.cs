using RestApi.Helpers;
using RestApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.ForView
{
    public class ZamowioneProduktyForView
    {
        [Key]
        [Column("ZamowienieID")]
        public int ZamowienieId { get; set; }
        public string? ZamowienieData { get; set; } = string.Empty;
        [Key]
        [Column("ProduktID")]
        public int ProduktId { get; set; }
        public string? ProduktData { get; set; } = string.Empty;
        public int Ilosc { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double CenaJednostkowa { get; set; }

        public static implicit operator ZamowioneProdukty(ZamowioneProduktyForView cli)
            => new ZamowioneProdukty().CopyProperties(cli);
        public static implicit operator ZamowioneProduktyForView(ZamowioneProdukty cli)
        {
            var result = new ZamowioneProduktyForView().CopyProperties(cli);
            result.ZamowienieData = cli?.Zamowienie != null
                ? $"{cli.Zamowienie.DataZamowienia:yyyy-MM-dd}"
                : string.Empty;

            result.ProduktData = cli?.Produkt?.Nazwa ?? string.Empty;
            return result;
        }
    }
}
