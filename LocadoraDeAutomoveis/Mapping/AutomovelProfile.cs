using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.WebApp.Models;
namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class AutomovelProfile : Profile
    {
        public AutomovelProfile()
        {
            CreateMap<InserirAutomovelViewModel, Automovel>();
            CreateMap<EditarAutomovelViewModel, Automovel>();

            CreateMap<Automovel, ListarAutomovelViewModel>()
                .ForMember(
                    dest => dest.GrupoAutomoveis,
                    opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome)
                );

            CreateMap<Automovel, DetalhesAutomovelViewModel>()
                .ForMember(
                    dest => dest.GrupoAutomoveis,
                    opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome)
                );

            CreateMap<Automovel, EditarAutomovelViewModel>();
        }
    }
}
