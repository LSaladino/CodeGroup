using PP.Core.Domain;

namespace PP.Manager.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa> DeletePessoaAsync(int id);

        Task<Pessoa> GetPessoaAsync(int id);

        Task<IEnumerable<Pessoa>> GetPessoasAsync();

        Task<Pessoa> InsertPessoaAsync(Pessoa pessoa);

        Task<Pessoa> UpdatePessoaAsync(Pessoa pessoa);
    }
}
