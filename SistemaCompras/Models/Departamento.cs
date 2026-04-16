using System.ComponentModel.DataAnnotations;

namespace SistemaCompras.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = "";

        [Required]
        public bool Estado { get; set; } // true = activo, false = inactivo
    }
}