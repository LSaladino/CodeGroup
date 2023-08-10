using Microsoft.EntityFrameworkCore;
using PP.Core.Domain;
using PP.Data.Context;
using PP.Manager.Interfaces.Repositories;

namespace PP.Data.Repository
{
    public class MembroRepository : IMembroRepository
    {
        private readonly MyDataContext _context;

        public MembroRepository(MyDataContext context)
        {
            _context = context;
        }

        public async Task<Membro> DeleteMembroAsync(int id)
        {
            var membroPesquisado = await _context.Membros!.FindAsync(id);

            if (membroPesquisado == null)
            {
                return null;
            }

            var membroRemovido = _context.Membros.Remove(membroPesquisado);

            await _context.SaveChangesAsync();

            return membroRemovido.Entity;

        }

        public async Task<IEnumerable<Membro>> GetAllMembrosAsync()
        {
            var membro = await _context.Membros!.AsNoTracking().ToListAsync();
            return membro;
        }

        public async Task<Membro> GetMembroByIdAsync(int id)
        {
            var membro = await _context.Membros!.SingleOrDefaultAsync(m => m.PessoaId == id);
            return membro!;
        }

        public async Task<Membro> PostMembroAsynch(Membro membro)
        {
            await _context.Membros!.AddAsync(membro);
            await _context.SaveChangesAsync();
            return membro;
        }
             

        public async Task<Membro> PutMembroAsync(Membro membro)
        {
            var membroConsultado = await _context.Membros!.FindAsync(membro.ProjetoId);

            if (membroConsultado == null)
            {
                return null;
            }

            _context.Entry(membroConsultado).CurrentValues.SetValues(membro);
            await _context.SaveChangesAsync();

            return membroConsultado;
        }
    }
}
