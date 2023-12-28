using ControleDeDespesas.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeDespesas.Data.Dtos.Despesa
{
    public class UpdateDespesaDto
    {
        public double Valor { get; set; }
        public TipoEnum Tipo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
