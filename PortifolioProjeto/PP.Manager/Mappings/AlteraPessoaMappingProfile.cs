using AutoMapper;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Pessoa;

namespace PP.Manager.Mappings
{
    public class AlteraPessoaMappingProfile: Profile
    {
        public AlteraPessoaMappingProfile()
        {
            CreateMap<AtualizaPessoa, Pessoa>();
               //.ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(_ => DateTime.Now))
               //.ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
        }
    }
}
