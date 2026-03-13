using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompras.Models
{
    public class OrdenCompra
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Número de la Orden")]
        public string NumeroOrden { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Fecha Orden")]
        public DateTime FechaOrden { get; set; } = DateTime.Now;

        [Required]
        public string Estado { get; set; } = "Generada";

        [Display(Name = "Identificador Solicitud")]
        public int? SolicitudCompraId { get; set; }

        [ForeignKey("SolicitudCompraId")]
        public SolicitudCompra? SolicitudCompra { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        [ForeignKey("ProveedorId")]
        public Proveedor? Proveedor { get; set; }

        public List<DetalleOrdenCompra> Detalles { get; set; } = new();
    }
}