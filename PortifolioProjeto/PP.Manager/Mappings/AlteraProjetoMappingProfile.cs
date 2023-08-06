using AutoMapper;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Projeto;

namespace PP.Manager.Mappings
{
    public class AlteraProjetoMappingProfile : Profile
    {
        public AlteraProjetoMappingProfile()
        {
            CreateMap<AtualizaProjeto, Projeto>();
        }
    }
}
