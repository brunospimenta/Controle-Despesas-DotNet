using System.ComponentModel.DataAnnotations;

namespace ControleDeDespesas.Models
{
    public class Conta
    {
        [Key]
        [Required]
        public int? Id { get; set; }
        public double Saldo { get; set; }
        public double Entrada { get; set; }
        public double Saida { get; set; }
        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
