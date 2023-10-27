using MarketListBackEnd.Model;
using MarketListBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarketListBackEnd.Controllers
{
    [Route("api/listadecompras")]
    [ApiController]
    public class ListaDeComprasController : ControllerBase
    {
        private readonly IListaDeComprasRepositorio _listaDeComprasRepositorio;

        public ListaDeComprasController(IListaDeComprasRepositorio listaDeComprasRepositorio)
        {
            _listaDeComprasRepositorio = listaDeComprasRepositorio;
        }

        // GET: api/listadecompras
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listasDeCompras = await _listaDeComprasRepositorio.GetAllAsync();
            return Ok(listasDeCompras);
        }

        // GET: api/listadecompras/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var listaDeCompras = await _listaDeComprasRepositorio.GetByIdAsync(id);
            if (listaDeCompras == null)
            {
                return NotFound();
            }
            return Ok(listaDeCompras);
        }

        // POST: api/listadecompras
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ListaDeCompras listaDeCompras)
        {
            if (ModelState.IsValid)
            {
                await _listaDeComprasRepositorio.InsertAsync(listaDeCompras);
                return Ok(listaDeCompras);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/listadecompras/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ListaDeCompras listaDeCompras)
        {
            if (id != listaDeCompras.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _listaDeComprasRepositorio.UpdateAsync(listaDeCompras);
                return Ok(listaDeCompras);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/listadecompras/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _listaDeComprasRepositorio.DeleteAsync(id);
            return NoContent();
        }
    }
}
