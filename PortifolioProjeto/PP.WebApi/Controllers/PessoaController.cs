using Microsoft.AspNetCore.Mvc;
using PP.Core.Shared.ModelViews.Pessoa;
using PP.Manager.Interfaces.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaManager pessoaManager;
        public PessoaController(IPessoaManager pessoaManager)
        {
            this.pessoaManager = pessoaManager;
        }

        // GET: api/<PessoaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pessoas = await pessoaManager.GetPessoasAsync();

            if (pessoas.Any())
            {
                return Ok(pessoas);
            }
            return NotFound();
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pessoa = await pessoaManager.GetPessoaAsync(id);
            if (pessoa.Id == 0)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        // POST api/<PessoaController>
        [HttpPost]
        public async Task<IActionResult> Post(NovaPessoa novaPessoa)
        {
            var pessoaInserida = await pessoaManager.InsertPessoaAsync(novaPessoa);
            return CreatedAtAction(nameof(Get), new { id = pessoaInserida.Id }, pessoaInserida);
        }

        // PUT api/<PessoaController>/5
        // all into of body, i don't need id parameter
        [HttpPut]
        public async Task<IActionResult> Put(AtualizaPessoa atualizaPessoa) 
        {
            var pessoaAtualizada = await pessoaManager.UpdatePessoaAsync(atualizaPessoa);

            if (pessoaAtualizada == null)
            {
                return NotFound();
            }
            return Ok(pessoaAtualizada);
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pessoaExcluida = await pessoaManager.DeletePessoaAsync(id);
            if (pessoaExcluida == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
