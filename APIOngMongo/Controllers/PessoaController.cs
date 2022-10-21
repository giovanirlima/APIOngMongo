using APIOngMongo.Models;
using APIOngMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIOngMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaServices _pessoaServices;

        public PessoaController(PessoaServices pessoaServices)
        {
            _pessoaServices = pessoaServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> Get() => await _pessoaServices.Get();

        [HttpGet("{id:length(24)}", Name = "Get")]
        public async Task<ActionResult<Pessoa>> Get(string id) => await _pessoaServices.Get(id);

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Create(Pessoa pessoa)
        {
            await _pessoaServices.Create(pessoa);

            return CreatedAtAction("Get", pessoa);
        }

        [HttpPut]
        public async Task<IActionResult> Put(string id, Pessoa pessoaIn)
        {
            var pessoa = _pessoaServices.Get(id);

            if (pessoa is null) return NotFound();

            pessoaIn.Id = id;

            await _pessoaServices.Put(id, pessoaIn);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            var pessoa = _pessoaServices.Get(id);

            if (pessoa is null) return NotFound();
            
            await _pessoaServices.Remove(id);

            return NoContent();
        }

    }
}
