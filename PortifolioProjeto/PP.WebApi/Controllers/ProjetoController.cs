using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Membro;
using PP.Core.Shared.ModelViews.Projeto;
using PP.Data.Repository;
using PP.Manager.Interfaces.Managers;
using PP.Manager.Interfaces.Repositories;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoManager _projetoManager;
        private readonly IMembroRepository _membroRepository;   
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;   

        public ProjetoController(IProjetoManager projetoManager,
            IMembroRepository membroRepository,
            IConfiguration configuration,
            IMapper mapper)
        {
            _projetoManager = projetoManager;
            _membroRepository = membroRepository;
            _configuration = configuration;
        }

        // GET: api/<ProjetoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projetos = await _projetoManager.GetProjetosAsync();

            if (projetos.Any())
            {
                return Ok(projetos);
            }

            return NotFound();
        }

        // GET api/<ProjetoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var projeto = await _projetoManager.GetProjetoByIdAsync(id);
            if(projeto.ProjetoId == 0)
            {
                return NotFound();
            }

            return Ok(projeto);
        }

        // POST api/<ProjetoController>
        [HttpPost]
        public async Task<IActionResult> Post(NovoProjeto novoProjeto)
        {
            var projetoInserido = await _projetoManager.InsertProjetoAsync(novoProjeto);
            if (projetoInserido.ProjetoId > 0)
            {

                Membro membro = new Membro();
                //membro.PessoaId = projetoInserido.PessoaId;

                membro.PessoaId = projetoInserido.PessoaId;
                membro.ProjetoId = projetoInserido.ProjetoId;


                await _membroRepository.PostMembroAsynch(membro);

            }
            return CreatedAtAction(nameof(Get), new { projetoId = projetoInserido.ProjetoId }, projetoInserido);    
        }

        // PUT api/<ProjetoController>/5
        [HttpPut]
        public async Task<IActionResult> Put(AtualizaProjeto atualizaProjeto)
        {
            var projetoAtualizado = await _projetoManager.UpdateProjetoAsync(atualizaProjeto);
            if(projetoAtualizado.ProjetoId == 0)
            {
                return NotFound();
            }

            return Ok(projetoAtualizado);
        }

        // DELETE api/<ProjetoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var projetoExcluido = await _projetoManager.DeleteProjetoByIdAsync(id);
            if (projetoExcluido == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
