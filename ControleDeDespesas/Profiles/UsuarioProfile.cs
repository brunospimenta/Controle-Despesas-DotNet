using AutoMapper;
using ControleDeDespesas.Data.Dtos.Usuario;
using ControleDeDespesas.Models;

namespace ControleDeDespesas.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, ReadUsuarioDto>()
                .ForMember(u => u.Role, opt => opt.MapFrom(u => u.Role)) ;
            CreateMap<UpdateUsuarioDto, Usuario>();
            
        }
    }
}
