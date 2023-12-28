using ControleDeDespesas.Models;
using System.ComponentModel.DataAnnotations;

namespace ControleDeDespesas.Data.Dtos.Usuario
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public int RoleId { get; set; }
        public int ContaId { get; set; }
    }
}
