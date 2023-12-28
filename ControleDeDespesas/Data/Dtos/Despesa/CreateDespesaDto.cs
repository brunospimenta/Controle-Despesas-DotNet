using ControleDeDespesas.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeDespesas.Data.Dtos.Despesa
{
    public class CreateDespesaDto
    {
        [Required]
        public DateTime Data_Adicao { get; set; } = DateTime.Now;
        [Required]
        public double Valor { get; set; }
        [Required]
        public TipoEnum Tipo { get; set; }
        [Required]
        public string Titulo { get; set; }
        public int planejamentoId { get; set; }
        public int UsuarioId { get; set; }
        public string Descricao { get; set; }
    }
}
