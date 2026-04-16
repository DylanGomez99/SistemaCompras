using System.ComponentModel.DataAnnotations;

namespace SistemaCompras.Models
{
    public class Marca
    {
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; } = "";

        [Required]
        public bool Estado { get; set; }
    }
}