using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompras.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "La cédula es obligatoria")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe tener exactamente 11 números")]
        public string Cedula { get; set; } = "";

        public int DepartamentoId { get; set; }

        [ForeignKey("DepartamentoId")]
        public Departamento? Departamento { get; set; }

        [Required]
        public bool Estado { get; set; } // 🔥 NUEVO
    }
}