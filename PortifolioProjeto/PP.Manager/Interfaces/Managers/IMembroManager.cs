using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Membro;

namespace PP.Manager.Interfaces.Managers
{
    public interface IMembroManager
    {
        Task<IEnumerable<MembroView>> GetAllMembrosAsync();
        Task<MembroView> GetMembroByIdAsync(int id);
        Task<MembroView> PostMembroAsynch(NovoMembro novoMembro);       
        Task<MembroView> PutMembroAsync(AtualizaMembro atualizaMembro); 
        Task<MembroView> DeleteMembroAsync(int id);
    }
}
