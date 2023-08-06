using PP.Core.Domain;

namespace PP.Manager.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<Projeto> DeleteProjetoByIdAsync(int id);

        Task<Projeto> GetProjetoByIdAsync(int id);

        Task<IEnumerable<Projeto>> GetProjetosAsync();  

        Task<Projeto> InsertProjetoAsync(Projeto projeto);

        Task<Projeto> UpdateProjetoAsync(Projeto projeto);  
    }
}
