using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompras.Models
{
    public class DetalleOrdenCompra
    {
        public int Id { get; set; }

        [Required]
        public int OrdenCompraId { get; set; }

        [ForeignKey("OrdenCompraId")]
        public OrdenCompra? OrdenCompra { get; set; }

        [Required]
        public int ArticuloId { get; set; }

        [ForeignKey("ArticuloId")]
        public Articulo? Articulo { get; set; }

        [Required]
        public int UnidadMedidaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public UnidadMedida? UnidadMedida { get; set; }

        [Required]
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca? Marca { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Costo Unitario")]
        public decimal CostoUnitario { get; set; }
    }
}