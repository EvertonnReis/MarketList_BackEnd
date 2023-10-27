using MarketListBackEnd.Model;
using MarketListBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarketListBackEnd.Controllers
{
    [Route("api/itenslistadecompras")]
    [ApiController]
    public class ItensListaDeComprasController : ControllerBase
    {
        private readonly IItensListaDeComprasRepositorio _itensListaDeComprasRepositorio;

        public ItensListaDeComprasController(IItensListaDeComprasRepositorio itensListaDeComprasRepositorio)
        {
            _itensListaDeComprasRepositorio = itensListaDeComprasRepositorio;
        }

        // GET: api/itenslistadecompras
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var itensListaDeCompras = await _itensListaDeComprasRepositorio.GetAllAsync();
            return Ok(itensListaDeCompras);
        }

        // GET: api/itenslistadecompras/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var itemListaDeCompras = await _itensListaDeComprasRepositorio.GetByIdAsync(id);
            if (itemListaDeCompras == null)
            {
                return NotFound();
            }
            return Ok(itemListaDeCompras);
        }

        // POST: api/itenslistadecompras
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItensListaDeCompras itemListaDeCompras)
        {
            if (ModelState.IsValid)
            {
                await _itensListaDeComprasRepositorio.InsertAsync(itemListaDeCompras);
                return Ok(itemListaDeCompras);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/itenslistadecompras/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ItensListaDeCompras itemListaDeCompras)
        {
            if (id != itemListaDeCompras.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _itensListaDeComprasRepositorio.UpdateAsync(itemListaDeCompras);
                return Ok(itemListaDeCompras);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/itenslistadecompras/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _itensListaDeComprasRepositorio.DeleteAsync(id);
            return NoContent();
        }
    }
}
