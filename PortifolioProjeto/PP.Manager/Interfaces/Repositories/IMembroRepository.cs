using PP.Core.Domain;

namespace PP.Manager.Interfaces.Repositories
{
    public interface IMembroRepository
    {
        Task<IEnumerable<Membro>> GetAllMembrosAsync();
        Task<Membro> GetMembroByIdAsync(int id);
        Task<Membro> PostMembroAsynch(Membro membro);
        Task<Membro> PutMembroAsync(Membro membro);
        Task<Membro> DeleteMembroAsync(int id);
    }
}
