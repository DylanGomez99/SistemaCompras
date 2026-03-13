using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompras.Models
{
    public class SolicitudCompra
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha Solicitud")]
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Empleado Solicitante")]
        public int EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleado? Empleado { get; set; }

        [Required]
        public string Estado { get; set; } = "Pendiente";

        public List<DetalleSolicitudCompra> Detalles { get; set; } = new();
    }
}