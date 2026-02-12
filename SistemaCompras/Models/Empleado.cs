using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompras.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Cargo { get; set; }

        public int DepartamentoId { get; set; }

        [ForeignKey("DepartamentoId")]
        public Departamento? Departamento { get; set; }
    }
}
