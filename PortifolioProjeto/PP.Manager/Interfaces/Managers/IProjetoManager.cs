using PP.Core.Shared.ModelViews.Projeto;

namespace PP.Manager.Interfaces.Managers
{
    public interface IProjetoManager
    {
        Task<ProjetoView> DeleteProjetoByIdAsync(int id);

        Task<ProjetoView> GetProjetoByIdAsync(int id);

        Task<IEnumerable<ProjetoView>> GetProjetosAsync();

        Task<ProjetoView> InsertProjetoAsync(NovoProjeto novoProjeto);

        Task<ProjetoView> UpdateProjetoAsync(AtualizaProjeto atualizaProjeto);  
    }
}
