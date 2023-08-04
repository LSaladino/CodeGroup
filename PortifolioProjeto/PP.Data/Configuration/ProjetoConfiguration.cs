using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Core.Domain;
using System.Reflection.Emit;

namespace PP.Data.Configuration
{
    public class ProjetoConfiguration: IEntityTypeConfiguration<Projeto>
    {
       public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("projeto");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.DataInicio).HasColumnName("data_inicio");
            builder.Property(p => p.DataPrevisaoFim).HasColumnName("data_previsao_fim");
            builder.Property(p => p.DataFim).HasColumnName("data_fim");
            builder.Property(p => p.Descricao).HasColumnName("descricao");
            builder.Property(p => p.Status).HasColumnName("status");
            builder.Property(p => p.Orcamento).HasColumnName("orcamento");
            builder.Property(p => p.Risco).HasColumnName("risco");
            builder.Property(p => p.PessoaId).HasColumnName("idgerente");

            //builder.HasOne(x => x.Pessoa)
            //      .WithMany(x => x.Projetos)
            //      .HasForeignKey(x => x.PessoaId)
            //      .HasConstraintName("fk_gerente");

        }
    }
}
