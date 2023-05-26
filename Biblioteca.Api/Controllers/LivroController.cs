using Biblioteca.Api.Domain;
using Biblioteca.Api.Enums;
using Biblioteca.Api.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private LivroHandler _handler;

        public LivroController()
        {
            _handler = new LivroHandler();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            Livro? livro = _handler.GetById(id);

            if (livro == null)
                return NotFound("Livro não encontrado!");

            return Ok(livro);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Post([FromBody] Livro livro)
        {
            LivroValidate validate = _handler.Post(livro);

            if (validate == LivroValidate.LivroExiste)
                return Conflict("Livro já cadastrado!");

            if (validate == LivroValidate.GeneroNaoExiste)
                return NotFound("Genero não encontrado");

            if (validate == LivroValidate.AutorNaoExiste)
                return NotFound("Autor não encontrado!");

            return Created($"api/Livro/{livro.Id}", livro);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Put([FromBody] Livro livro)
        {
            LivroValidate validate = _handler.Put(livro);

            if (validate == LivroValidate.LivroNaoExiste)
                return NotFound("Livro não encontrado");

            if (validate == LivroValidate.GeneroNaoExiste)
                return NotFound("Genero não encontrado");

            if (validate == LivroValidate.AutorNaoExiste)
                return NotFound("Autor não encontrado!");

            return Ok(livro);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(long id)
        {
            if (_handler.DeleteById(id))
                return Ok();

            return NotFound("Livro não encontrado!");
        }
    }
}
