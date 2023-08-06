using Microsoft.AspNetCore.Mvc;
using PP.Core.Domain;
using PP.Core.Shared.ModelViews.Projeto;
using PP.Manager.Interfaces.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoManager _projetoManager;

        public ProjetoController(IProjetoManager projetoManager)
        {
            _projetoManager = projetoManager;
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
