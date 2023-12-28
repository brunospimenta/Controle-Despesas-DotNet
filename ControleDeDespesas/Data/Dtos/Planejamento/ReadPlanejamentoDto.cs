using ControleDeDespesas.Data.Dtos.Despesa;
using ControleDeDespesas.Data.Dtos.Usuario;

namespace ControleDeDespesas.Data.Dtos.Planejamento
{
    public class ReadPlanejamentoDto
    {
        public int Id { get; set; }
        public double Valor_a_gastar { get; set; }
        public DateTime Data_Adicao { get; set; } = DateTime.Now;
        public ICollection<ReadDespesaWoUserDto> Despesas { get; set; }
        public ReadUsuarioDto Usuario { get; set; }
    }
}
