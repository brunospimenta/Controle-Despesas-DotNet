using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeDespesas.Models
{
    public class Usuario : IdentityUser<int>
    {        
        public DateTime DataNascimento { get; set; }
        public Usuario() : base() { }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int ContaId { get; set; }
        public virtual Conta Conta { get; set; }
        public virtual ICollection<Despesa>? Despesas { get; set; }
        public virtual ICollection<Planejamento>? Planejamentos { get; set; }
    }
}
