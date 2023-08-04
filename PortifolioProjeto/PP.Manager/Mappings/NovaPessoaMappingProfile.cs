using AutoMapper;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Pessoa;

namespace PP.Manager.Mappings
{
    public class NovaPessoaMappingProfile : Profile
    {
        public NovaPessoaMappingProfile()
        {
            CreateMap<NovaPessoa, Pessoa>();
            CreateMap<Pessoa, PessoaView>();    
        }
    }
}
