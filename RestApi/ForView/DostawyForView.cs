using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestApi.Helpers;
using RestApi.Models;

namespace RestApi.ForView
{
    public class DostawyForView
    {
        [Key]
        [Column("DostawaID")]
        public int DostawaId { get; set; }
        [Column("DostawcaID")]
        public int? DostawcaId { get; set; }
        public string? DostawcaData { get; set; } = default!;
        [Column(TypeName = "datetime")]
        public DateTime DataDostawy { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? StatusDostawy { get; set; }

        public static implicit operator Dostawy(DostawyForView cli)
            => new Dostawy().CopyProperties(cli);
        public static implicit operator DostawyForView(Dostawy cli)
            => new DostawyForView() 
            { 
                DostawcaData = cli?.Dostawca?.Nazwa??string.Empty
            }.CopyProperties(cli);
    }
}
