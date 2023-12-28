namespace ControleDeDespesas.Data.Dtos.Conta
{
    public class CreateContaDto
    {
        public double Saldo { get; set; }
        public double Entrada { get; set; }
        public double Saida { get; set; }
        public int UsuarioId { get; set; }
    }
}
