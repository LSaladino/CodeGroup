using Microsoft.EntityFrameworkCore;
using PP.Core.Domain;
using PP.Data.Context;
using PP.Manager.Interfaces.Repositories;

namespace PP.Data.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly MyDataContext _myDataContext;

        public ProjetoRepository(MyDataContext myDataContext)
        {
            _myDataContext = myDataContext;
        }

        public async Task<Projeto> DeleteProjetoAsync(int id)
        {
            var projetoPesquisado = await _myDataContext.Projetos.SingleOrDefaultAsync(p => p.ProjetoId == id); 
            if(projetoPesquisado == null)
            {
                return null;
            }

            var projetoRemovido = _myDataContext.Projetos.Remove(projetoPesquisado);    

            await _myDataContext.SaveChangesAsync();
            return projetoRemovido.Entity;
        }

        public async Task<Projeto> GetProjetoAsync(int id)
        {
            return await _myDataContext.Projetos.SingleOrDefaultAsync(p => p.PessoaId == id);
        }

        public async Task<IEnumerable<Projeto>> GetProjetosAsync()
        {
            return await _myDataContext.Projetos.AsNoTracking().ToListAsync();
        }

        public async Task<Projeto> InsertProjetoAsync(Projeto projeto)
        {
            await _myDataContext.Projetos.AddAsync(projeto);
            await _myDataContext.SaveChangesAsync();
            return projeto;
        }

        public async Task<Projeto> UpdateProjetoAsync(Projeto projeto)
        {
            var projetoPesquisado = await _myDataContext.Projetos.SingleOrDefaultAsync(p => p.ProjetoId == projeto.ProjetoId);
            if(projetoPesquisado == null)
            {
                return null;
            }

            _myDataContext.Entry(projetoPesquisado).CurrentValues.SetValues(projeto);
            await _myDataContext.SaveChangesAsync();

            return projetoPesquisado;
        }
    }
}
