using System.ComponentModel.DataAnnotations;

namespace SistemaCompras.Models
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
