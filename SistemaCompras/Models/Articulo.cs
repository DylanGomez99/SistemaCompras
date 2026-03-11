using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompras.Models
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un monto")]
        [Range(0.01, 1000000, ErrorMessage = "El monto debe ser mayor que 0")]
        public decimal Monto { get; set; }

        public int MarcaId { get; set; }
        public int UnidadMedidaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca? Marca { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public UnidadMedida? UnidadMedida { get; set; }
    }
}