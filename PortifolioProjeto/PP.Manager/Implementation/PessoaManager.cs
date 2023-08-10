using AutoMapper;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Pessoa;
using PP.Manager.Interfaces.Managers;
using PP.Manager.Interfaces.Repositories;

namespace PP.Manager.Implementation
{
    public class PessoaManager : IPessoaManager
    {
        private readonly IPessoaRepository? pessoaRepository;
        private readonly IMapper mapper;

        public PessoaManager(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            this.pessoaRepository = pessoaRepository;
            this.mapper = mapper;
        }

        public async Task<PessoaView> DeletePessoaByIdAsync(int id)
        {
            var pessoaExcluida = await pessoaRepository.DeletePessoaByIdAsync(id);
            return mapper.Map<PessoaView>(pessoaExcluida);

        }

        public async Task<PessoaView> GetPessoaByIdAsync(int id)
        {
            var pessoa = await pessoaRepository.GetPessoaByIdAsync(id);
            return mapper.Map<PessoaView>(pessoa);
        }

        public async Task<IEnumerable<PessoaView>> GetPessoasAsync()
        {
            var pessoas = await pessoaRepository!.GetPessoasAsync();
            return mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaView>>(pessoas);
        }

        public async Task<IEnumerable<PessoaTwoFieldsView>> GetPessoasTwoFieldsAsync()
        {
            var pessoas = await pessoaRepository!.GetPessoasTwoFieldsAsync();
            return mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaTwoFieldsView>>(pessoas);
        }

        public async Task<PessoaTwoFieldsView> GetPessoasTwoFieldsByIdAsync(int id)
        {
            var pessoas = await pessoaRepository!.GetPessoasTwoFieldsByIdAsync(id);
            return mapper.Map<Pessoa, PessoaTwoFieldsView>(pessoas);
        }

        public async Task<PessoaView> InsertPessoaAsync(NovaPessoa novaPessoa)
        {
            var pessoa = mapper.Map<Pessoa>(novaPessoa);
            pessoa = await pessoaRepository.InsertPessoaAsync(pessoa);
            return mapper.Map<PessoaView>(pessoa);
        }

        public async Task<PessoaView> UpdatePessoaAsync(AtualizaPessoa atualizaPessoa)    
        {
            var pessoa = mapper.Map<Pessoa>(atualizaPessoa);
            pessoa = await pessoaRepository.UpdatePessoaAsync(pessoa);
            return mapper.Map<PessoaView>(pessoa);
        }
    }
}
