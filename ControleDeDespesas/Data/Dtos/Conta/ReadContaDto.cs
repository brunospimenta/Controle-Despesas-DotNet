using ControleDeDespesas.Data.Dtos.Usuario;

namespace ControleDeDespesas.Data.Dtos.Conta
{
    public class ReadContaDto
    {
        public int? Id { get; set; }
        public double Saldo { get; set; }
        public double Entrada { get; set; }
        public double Saida { get; set; }
        public ReadUsuarioDto Usuario { get; set; }
    }
}
