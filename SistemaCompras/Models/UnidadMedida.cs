using System.ComponentModel.DataAnnotations;

namespace SistemaCompras.Models
{
    public class UnidadMedida
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
