using ControleDeDespesas.Data.Dtos.Usuario;
using ControleDeDespesas.Enums;

namespace ControleDeDespesas.Data.Dtos.Despesa
{
    public class ReadDespesaWoUserDto
    {
        public int Id { get; set; }
        public DateTime Data_Adicao { get; set; } = DateTime.Now;
        public double Valor { get; set; }
        public TipoEnum Tipo { get; set; }
        public string Titulo { get; set; }
        public int PlanejamentoId { get; set; }
        public string Descricao { get; set; }
    }
}
