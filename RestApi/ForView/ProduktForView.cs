using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestApi.Helpers;
using RestApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace RestApi.ForView
{
    public class ProduktForView
    {
        [Key]
        [Column("ProduktID")]
        public int ProduktId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Nazwa { get; set; } = null!;
        [Column(TypeName = "text")]
        public string? Opis { get; set; }
        [SwaggerSchema(Format = "decimal")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cena { get; set; }
        public int StanMagazynowy { get; set; }
        [Column("KategoriaID")]
        public int? KategoriaId { get; set; }
        public string? KategoriaData { get; set; } = default!;

        public static implicit operator Produkty(ProduktForView cli)
            => new Produkty().CopyProperties(cli);
        public static implicit operator ProduktForView(Produkty cli)
            => new ProduktForView()
            {
                KategoriaData = cli?.Kategorie?.Nazwa ?? string.Empty
            }.CopyProperties(cli);
            
    }
}
