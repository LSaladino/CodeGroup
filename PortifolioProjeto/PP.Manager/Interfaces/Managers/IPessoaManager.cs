using PP.Core.Shared.ModelViews.Pessoa;

namespace PP.Manager.Interfaces.Managers
{
    public interface IPessoaManager
    {
        Task<PessoaView> DeletePessoaByIdAsync(int id);

        Task<PessoaView> GetPessoaByIdAsync(int id);

        Task<IEnumerable<PessoaView>> GetPessoasAsync();
        Task<IEnumerable<PessoaTwoFieldsView>> GetPessoasTwoFieldsAsync();
        Task<PessoaTwoFieldsView> GetPessoasTwoFieldsByIdAsync(int id);

        Task<PessoaView> InsertPessoaAsync(NovaPessoa novaPessoa);

        Task<PessoaView> UpdatePessoaAsync(AtualizaPessoa atualizaPessoa);          
    }
}
