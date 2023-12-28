using System.ComponentModel.DataAnnotations;

namespace ControleDeDespesas.Data.Dtos.Role
{
    public class CreateRoleDto
    {
        [Required]
        public string Name { get; set; }        
        public string descricao { get; set; }

    }
}
