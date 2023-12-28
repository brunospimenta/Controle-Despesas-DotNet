using AutoMapper;
using ControleDeDespesas.Data.Dtos.Despesa;
using ControleDeDespesas.Data.Dtos.Planejamento;
using ControleDeDespesas.Models;

namespace ControleDeDespesas.Profiles
{
    public class PlanejamentoProfile : Profile
    {
        public PlanejamentoProfile()
        {
            CreateMap<CreatePlanejamentoDto, Planejamento>();
            CreateMap<Planejamento, ReadPlanejamentoDto>()
                .ForMember(p => p.Usuario, opt => opt.MapFrom(p => p.Usuario))
                .ForMember(p => p.Despesas, opt => opt.MapFrom(p => p.Despesa));
            CreateMap<UpdatePlanejamentoDto, Planejamento>();
        }
    }
}
