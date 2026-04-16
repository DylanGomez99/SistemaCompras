using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompras.Models
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; } = "";

        [Required(ErrorMessage = "Debe ingresar la existencia")]
        [Range(0, 1000000, ErrorMessage = "La existencia no puede ser negativa")]
        public int Existencia { get; set; }

        [Required]
        public bool Estado { get; set; } = true;

        public int MarcaId { get; set; }
        public int UnidadMedidaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca? Marca { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public UnidadMedida? UnidadMedida { get; set; }
    }
}