using Biblioteca.Api.Domain;
using Biblioteca.Api.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private AutorHandler _handler;

        public AutorController()
        {
            _handler = new AutorHandler();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            Autor? autor = _handler.GetById(id);

            if (autor == null)
                return NotFound("Autor não encontrado!");

            return Ok(autor);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Post([FromBody] Autor autor)
        {
            if (_handler.Post(autor))
                return Created($"api/Autor/{autor.Id}", autor);

            return Conflict("Autor já está cadastrado!");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Put([FromBody] Autor autor)
        {
            if (_handler.Put(autor))
                return Ok(autor);

            return NotFound("Autor não encontrado!");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(long id)
        {
            if (_handler.DeleteById(id))
                return Ok();

            return NotFound("Autor não encontrado!");
        }
    }
}
