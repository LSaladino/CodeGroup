using PP.Manager.Mappings;
namespace PP.WebApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(
            typeof(NovaPessoaMappingProfile),
            typeof(AlteraPessoaMappingProfile),
            typeof(NovoProjetoMappingProfile),
            typeof(AlteraProjetoMappingProfile)
            );
        }
    }
}
