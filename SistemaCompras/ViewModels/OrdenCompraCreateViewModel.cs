using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaCompras.ViewModels
{
    public class OrdenCompraDetalleInputModel
    {
        [Required]
        public int ArticuloId { get; set; }

        [Required]
        public int UnidadMedidaId { get; set; }

        [Required]
        public int MarcaId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [Range(0.01, 999999999)]
        public decimal CostoUnitario { get; set; }
    }

    public class OrdenCompraCreateViewModel
    {
        [Required]
        public string NumeroOrden { get; set; } = string.Empty;

        public int? SolicitudCompraId { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        [Required]
        public string Estado { get; set; } = "Generada";

        public List<OrdenCompraDetalleInputModel> Detalles { get; set; } = new();

        public SelectList? Proveedores { get; set; }
        public SelectList? Solicitudes { get; set; }
        public SelectList? Articulos { get; set; }
        public SelectList? UnidadesMedida { get; set; }
        public SelectList? Marcas { get; set; }
    }
}