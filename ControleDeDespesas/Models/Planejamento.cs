using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeDespesas.Models
{
    public class Planejamento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public double Valor_a_gastar { get; set; }
        public DateTime Data_Adicao { get; set; } = DateTime.Now;
        public virtual ICollection<Despesa> Despesa { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
