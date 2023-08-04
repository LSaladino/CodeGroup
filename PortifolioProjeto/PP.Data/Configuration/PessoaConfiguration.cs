using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Core.Domain;

namespace PP.Data.Configuration
{
    public class PessoaConfiguration: IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.DataNascimento).HasColumnName("datanascimento");
            builder.Property(p => p.CPF).HasColumnName("cpf");
            builder.Property(p => p.IsFuncionario).HasColumnName("funcionario");
            
        }
    }
}
