using System.ComponentModel.DataAnnotations;

namespace SistemaCompras.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}