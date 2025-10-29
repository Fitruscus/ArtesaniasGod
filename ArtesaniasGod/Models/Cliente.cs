using System.ComponentModel.DataAnnotations;

namespace AutenticacionASPNET.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(320)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(350)]
        public string? Direccion { get; set; }

        [Required]
        public int CarnetIdentidad { get; set; }
    }
}
