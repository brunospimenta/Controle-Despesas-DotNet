using AutoMapper;
using ControleDeDespesas.Data.Dtos.Role;
using ControleDeDespesas.Models;

namespace ControleDeDespesas.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile() 
        {
            CreateMap<CreateRoleDto, Role>();
            CreateMap<Role, ReadRoleDto>();
        }
    }
}
