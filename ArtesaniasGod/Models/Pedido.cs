using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticacionASPNET.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; }

        [Required]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        [MaxLength(350)]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal MontoTotal { get; set; }

        public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
    }
}
