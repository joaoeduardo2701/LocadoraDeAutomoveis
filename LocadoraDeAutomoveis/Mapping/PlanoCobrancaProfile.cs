using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class PlanoCobrancaProfile : Profile
{
    public PlanoCobrancaProfile()
    {
        CreateMap<InserirPlanoCobrancaViewModel, PlanoCobranca>();
        CreateMap<EditarPlanoCobrancaViewModel, PlanoCobranca>();

        CreateMap<PlanoCobranca, ListarPlanoCobrancaViewModel>()
            .ForMember(
                dest => dest.GrupoVeiculos,
                opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));

        CreateMap<PlanoCobranca, DetalhesPlanoCobrancaViewModel>()
            .ForMember(
                dest => dest.GrupoVeiculos,
                opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));

        CreateMap<PlanoCobranca, EditarPlanoCobrancaViewModel>();
    }
}