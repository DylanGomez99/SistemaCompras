using System.ComponentModel.DataAnnotations;

namespace SistemaCompras.Models
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cédula / RNC")]
        public string CedulaRnc { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nombre Comercial")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Estado { get; set; } = "Activo";

        public string? Telefono { get; set; }

        public string? Email { get; set; }
    }
}