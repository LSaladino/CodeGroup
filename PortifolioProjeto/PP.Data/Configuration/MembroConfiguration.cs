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
            builder.Property(p => p.Id).HasColumnName("idprojeto");
            builder.Property(p => p.PessoaId).HasColumnName("idpessoa");

            builder.HasOne(x => x.Pessoa)
                .WithMany(x => x.Membro)
                .HasForeignKey(x => x.PessoaId)
                .HasConstraintName("fk_membros_pessoa");
        }
    }
}
