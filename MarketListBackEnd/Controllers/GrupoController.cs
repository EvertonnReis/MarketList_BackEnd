using MarketListBackEnd.Model;
using MarketListBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarketListBackEnd.Controllers
{
    [Route("api/grupo")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public GrupoController(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        // GET: api/grupo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var grupos = await _grupoRepositorio.GetAllAsync();
            return Ok(grupos);
        }

        // GET: api/grupo/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var grupo = await _grupoRepositorio.GetByIdAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            return Ok(grupo);
        }

        // POST: api/grupo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                await _grupoRepositorio.InsertAsync(grupo);
                return Ok(grupo);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/grupo/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Grupo grupo)
        {
            if (id != grupo.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _grupoRepositorio.UpdateAsync(grupo);
                return Ok(grupo);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/grupo/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _grupoRepositorio.DeleteAsync(id);
            return NoContent();
        }
    }
}
