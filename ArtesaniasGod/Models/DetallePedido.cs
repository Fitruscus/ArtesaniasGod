using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticacionASPNET.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }

        [Required]
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }

        [Required]
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Subtotal { get; set; }
    }
}
