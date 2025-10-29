using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticacionASPNET.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
