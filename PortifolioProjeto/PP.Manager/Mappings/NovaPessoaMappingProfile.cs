using AutoMapper;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Pessoa;

namespace PP.Manager.Mappings
{
    public class NovaPessoaMappingProfile : Profile
    {
        public NovaPessoaMappingProfile()
        {
            //        de          para
            CreateMap<NovaPessoa, Pessoa>();
            CreateMap<Pessoa, PessoaView>();
            CreateMap<Pessoa, PessoaTwoFieldsView>();
        }
    }
}
