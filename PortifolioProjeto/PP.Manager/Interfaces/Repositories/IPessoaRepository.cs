using PP.Core.Domain;

namespace PP.Manager.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa> DeletePessoaByIdAsync(int id); 

        Task<Pessoa> GetPessoaByIdAsync(int id);    

        Task<IEnumerable<Pessoa>> GetPessoasAsync();

        Task<IEnumerable<Pessoa>> GetPessoasTwoFieldsAsync();
        Task<Pessoa> GetPessoasTwoFieldsByIdAsync(int id);   

        Task<Pessoa> InsertPessoaAsync(Pessoa pessoa);

        Task<Pessoa> UpdatePessoaAsync(Pessoa pessoa);
    }
}
