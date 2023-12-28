using ControleDeDespesas.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeDespesas.Models
{
    public class Despesa
    {
        [Key]
        [Required]
        public int? Id { get; set; }
        [Required]
        public DateTime Data_Adicao { get; set; } = DateTime.Now;
        [Required]
        public double Valor { get; set; }
        [Required]
        public TipoEnum Tipo { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int PlanejamentoId { get; set; }
        public virtual Planejamento Planejamento { get; set; }
        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
