using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompras.Models
{
    public class DetalleSolicitudCompra
    {
        public int Id { get; set; }

        [Required]
        public int SolicitudCompraId { get; set; }

        [ForeignKey("SolicitudCompraId")]
        public SolicitudCompra? SolicitudCompra { get; set; }

        [Required]
        public int ArticuloId { get; set; }

        [ForeignKey("ArticuloId")]
        public Articulo? Articulo { get; set; }

        [Required]
        public int UnidadMedidaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public UnidadMedida? UnidadMedida { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }
    }
}