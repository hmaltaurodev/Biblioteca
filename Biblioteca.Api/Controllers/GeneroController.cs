using Biblioteca.Api.Domain;
using Biblioteca.Api.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
        private GeneroHandler _handler;

        public GeneroController()
        {
            _handler = new GeneroHandler();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            Genero? genero = _handler.GetById(id);

            if (genero == null)
                return NotFound("Genero não encontrado!");

            return Ok(genero);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Post([FromBody] Genero genero)
        {
            if (_handler.Post(genero))
                return Created($"api/Genero/{genero.Id}", genero);

            return Conflict("Genero já está cadastrado!");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Put([FromBody] Genero genero)
        {
            if (_handler.Put(genero))
                return Ok(genero);

            return NotFound("Genero não encontrado!");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(long id)
        {
            if (_handler.DeleteById(id))
                return Ok();

            return NotFound("Genero não encontrado!");
        }
    }
}
