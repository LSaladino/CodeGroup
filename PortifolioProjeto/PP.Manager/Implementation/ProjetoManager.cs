using AutoMapper;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Projeto;
using PP.Manager.Interfaces.Managers;
using PP.Manager.Interfaces.Repositories;

namespace PP.Manager.Implementation
{
    public class ProjetoManager : IProjetoManager
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetoManager(IProjetoRepository projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        public async Task<ProjetoView> DeleteProjetoByIdAsync(int id)
        {
            var projetoExcluido = await _projetoRepository.DeleteProjetoByIdAsync(id);
            return _mapper.Map<ProjetoView>(projetoExcluido);
        }

        public async Task<ProjetoView> GetProjetoByIdAsync(int id)
        {
            var projeto = await _projetoRepository.GetProjetoByIdAsync(id);
            return _mapper.Map<Projeto,  ProjetoView>(projeto);
        }

        public async Task<IEnumerable<ProjetoView>> GetProjetosAsync()
        {
            var projetos = await _projetoRepository!.GetProjetosAsync();
            return _mapper.Map<IEnumerable<Projeto>, IEnumerable<ProjetoView>>(projetos);
        }

        public async Task<ProjetoView> InsertProjetoAsync(NovoProjeto novoProjeto)
        {
            var projeto = _mapper.Map<Projeto>(novoProjeto);
            projeto = await _projetoRepository.InsertProjetoAsync(projeto);
            return _mapper.Map<ProjetoView>(projeto);

        }

        public async Task<ProjetoView> UpdateProjetoAsync(AtualizaProjeto atualizaProjeto)
        {
            var projeto = _mapper.Map<Projeto>(atualizaProjeto);
            //projeto = await _projetoRepository.UpdateProjetoAsync(projeto);
            return _mapper.Map<ProjetoView>(await _projetoRepository.UpdateProjetoAsync(projeto));
        }
    }
}
