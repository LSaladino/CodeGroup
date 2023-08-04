using Microsoft.EntityFrameworkCore;
using PP.Core.Domain;
using PP.Data.Configuration;

namespace PP.Data.Context
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Pessoa>? Pessoas { get; set; }
        public DbSet<Projeto>? Projetos { get; set; }
        public DbSet<Membro>? Membros { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            modelBuilder.ApplyConfiguration(new ProjetoConfiguration());
            modelBuilder.ApplyConfiguration(new MembroConfiguration());
        }
    }
}
