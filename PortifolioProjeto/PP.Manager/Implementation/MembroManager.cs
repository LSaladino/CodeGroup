using AutoMapper;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Membro;
using PP.Manager.Interfaces.Managers;
using PP.Manager.Interfaces.Repositories;

namespace PP.Manager.Implementation
{
    public class MembroManager : IMembroManager
    {
        private readonly IMembroRepository _membroRepository;
        private readonly IMapper _mapper;

        public MembroManager(IMembroRepository membroRepository, IMapper mapper)
        {
            _membroRepository = membroRepository;
            _mapper = mapper;
        }

        public async Task<MembroView> DeleteMembroAsync(int id)
        {
            var membroExcluido = await _membroRepository.DeleteMembroAsync(id);
            return _mapper.Map<MembroView>(membroExcluido);

        }

        public async Task<IEnumerable<MembroView>> GetAllMembrosAsync()
        {
            var membros = await _membroRepository.GetAllMembrosAsync();
            return _mapper.Map<IEnumerable<Membro>, IEnumerable<MembroView>>(membros);
        }

        public async Task<MembroView> GetMembroByIdAsync(int id)
        {
            var membro = await _membroRepository.GetMembroByIdAsync(id);
            return _mapper.Map<MembroView>(membro);
        }

        public async Task<MembroView> PostMembroAsynch(NovoMembro novoMembro)       
        {
            var membro = _mapper.Map<Membro>(novoMembro);
            membro = await _membroRepository.PostMembroAsynch(membro);
            return _mapper.Map<MembroView>(membro);
           
        }

        public async Task<MembroView> PutMembroAsync(AtualizaMembro atualizaMembro)   
        {
            var membro = _mapper.Map<Membro>(atualizaMembro);
            membro = await _membroRepository.PutMembroAsync(membro);
            return _mapper.Map<MembroView>(membro);
        }
    }
}
