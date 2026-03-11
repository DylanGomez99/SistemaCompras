using System.ComponentModel.DataAnnotations;

namespace SistemaCompras.Models
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "El RNC es obligatorio")]
        [RegularExpression(@"^\d{9}$|^\d{11}$", ErrorMessage = "El RNC debe tener 9 u 11 números")]
        public string RNC { get; set; }
    }
}