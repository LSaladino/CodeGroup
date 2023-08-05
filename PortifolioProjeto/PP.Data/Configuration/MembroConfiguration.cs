using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Core.Domain;
using System.Reflection.Emit;

namespace PP.Data.Configuration
{
    public class MembroConfiguration : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.ToTable("membros");
            builder.Property(p => p.PessoaId).HasColumnName("idpessoa");
            builder.Property(p => p.ProjetoId).HasColumnName("idprojeto");
            builder.HasKey(p => p.ProjetoId).HasName("pk_membros_projeto");
                
            
        }
    }
}
