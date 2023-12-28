using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ControleDeDespesas.Models
{
    public class Role : IdentityRole<int>
    {
        public string descricao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
