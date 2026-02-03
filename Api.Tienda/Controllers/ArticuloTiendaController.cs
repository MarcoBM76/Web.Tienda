using BussinessLogic.Features.ArticuloTienda.DTO_s;
using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloTiendaController : ControllerBase
    {
        private IArticuloTiendaService _articuloTiendaService;
        public ArticuloTiendaController(IArticuloTiendaService articuloTiendaService)
        {
            _articuloTiendaService = articuloTiendaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticuloTiendaId([FromRoute] int id)
        {
            var articuloTienda = await _articuloTiendaService.GetArticuloTienda(id);
            return articuloTienda != null
                ? Ok(articuloTienda)
                : NotFound();
        }

        [HttpGet]
        public IActionResult GetAllArticuloTienda()
        {
            var articuloTiendas = _articuloTiendaService.GetAllArticuloTienda();
            return Ok(articuloTiendas);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticuloTienda([FromBody] AddArticuloTiendaDTO articuloTienda)
        {
            var articuloTiendaId = await _articuloTiendaService.AddArticuloTienda(articuloTienda);
            return CreatedAtAction(nameof(GetArticuloTiendaId), new { id = articuloTiendaId }, articuloTiendaId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticuloTienda([FromRoute] int id)
        {
            var result = await _articuloTiendaService.DeleteArticuloTienda(id);
            return result
                ? NoContent()
                : NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateArticuloTienda([FromBody] UpdateArticuloTiendaDTO articuloTienda)
        {
            var result = await _articuloTiendaService.UpdateArticuloTienda(articuloTienda);
            return result
                ? NoContent()
                : NotFound();
        }



    }
}
