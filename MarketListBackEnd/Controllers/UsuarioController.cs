using MarketListBackEnd.Model;
using MarketListBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarketListBackEnd.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _usuarioRepositorio.GetAllAsync();
            return Ok(usuarios);
        }

        // GET: api/usuario/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioRepositorio.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioRepositorio.InsertAsync(usuario);
                return Ok(usuario);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/usuario/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _usuarioRepositorio.UpdateAsync(usuario);
                return Ok(usuario);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/usuario/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioRepositorio.DeleteAsync(id);
            return NoContent();
        }
    }
}
