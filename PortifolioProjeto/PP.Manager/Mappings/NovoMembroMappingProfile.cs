using AutoMapper;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Membro;

namespace PP.Manager.Mappings
{
    public class NovoMembroMappingProfile :Profile
    {
        public NovoMembroMappingProfile()
        {
            CreateMap<NovoMembro, Membro>();
            CreateMap<Membro, MembroView>();
            CreateMap<Membro, NovoMembro>();
        }
    }
}
