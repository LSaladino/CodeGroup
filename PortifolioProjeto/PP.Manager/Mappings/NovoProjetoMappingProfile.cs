using AutoMapper;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Projeto;

namespace PP.Manager.Mappings
{
    public class NovoProjetoMappingProfile : Profile
    {
        public NovoProjetoMappingProfile()
        {
            CreateMap<NovoProjeto, Projeto>();
            CreateMap<Projeto, ProjetoView>();
        }
    }
}
