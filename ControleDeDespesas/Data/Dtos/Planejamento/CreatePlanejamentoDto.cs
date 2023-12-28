using ControleDeDespesas.Models;

namespace ControleDeDespesas.Data.Dtos.Planejamento
{
    public class CreatePlanejamentoDto
    {
        public double Valor_a_gastar { get; set; }
        public DateTime Data_Adicao { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
    }
}
