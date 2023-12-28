using AutoMapper;
using ControleDeDespesas.Data.Dtos.Despesa;
using ControleDeDespesas.Data.Dtos.Planejamento;
using ControleDeDespesas.Models;

namespace ControleDeDespesas.Profiles
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile() 
        {
            CreateMap<CreateDespesaDto, Despesa>();
            CreateMap<Despesa, ReadDespesaDto>()
                .ForMember(d => d.PlanejamentoId, opt => opt.MapFrom(d => d.PlanejamentoId))
                .ForMember(d => d.Usuario, opt => opt.MapFrom(d => d.Usuario));
            CreateMap<UpdateDespesaDto, Despesa>();
            CreateMap<Despesa, ReadDespesaWoUserDto>()
                .ForMember(d => d.PlanejamentoId, opt => opt.MapFrom(d => d.PlanejamentoId));
        }
        
    }
}
