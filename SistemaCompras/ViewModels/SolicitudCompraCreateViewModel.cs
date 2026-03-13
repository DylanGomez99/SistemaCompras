using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaCompras.ViewModels
{
    public class SolicitudCompraDetalleInputModel
    {
        [Required]
        public int ArticuloId { get; set; }

        [Required]
        public int UnidadMedidaId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }
    }

    public class SolicitudCompraCreateViewModel
    {
        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        public string Estado { get; set; } = "Pendiente";

        public List<SolicitudCompraDetalleInputModel> Detalles { get; set; } = new();

        public SelectList? Empleados { get; set; }
        public SelectList? Articulos { get; set; }
        public SelectList? UnidadesMedida { get; set; }
    }
}