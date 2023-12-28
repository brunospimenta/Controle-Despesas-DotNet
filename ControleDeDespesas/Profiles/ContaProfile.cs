using AutoMapper;
using ControleDeDespesas.Data.Dtos.Conta;
using ControleDeDespesas.Data.Dtos.Despesa;
using ControleDeDespesas.Models;

namespace ControleDeDespesas.Profiles
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<CreateContaDto, Conta>();
            CreateMap<Conta, ReadContaDto>();
            CreateMap<UpdateContaDto, Conta>();

        }
    }
}
