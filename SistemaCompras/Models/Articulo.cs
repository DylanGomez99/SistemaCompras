using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompras.Models
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int MarcaId { get; set; }
        public int UnidadMedidaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca? Marca { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public UnidadMedida? UnidadMedida { get; set; }
    }
}
