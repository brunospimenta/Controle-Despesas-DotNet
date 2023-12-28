using ControleDeDespesas.Data.Dtos.Role;
using System.ComponentModel.DataAnnotations;

namespace ControleDeDespesas.Data.Dtos.Usuario
{
    public class ReadUsuarioDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DataNascimento { get; set; }
        public ReadRoleDto Role { get; set; }                     
    }
}
