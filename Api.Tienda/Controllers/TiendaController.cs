using BussinessLogic.Features.Tienda.DTO_s;
using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private ITiendaService _tiendaService;
        public TiendaController(ITiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }

        [HttpGet("{tiendaId}")]
        public async Task<IActionResult> GetTiendaById([FromRoute] int tiendaId)
        {
            var tienda = await _tiendaService.GetTiendaById(tiendaId);

            return tienda != null
                ? Ok(tienda)
                : NotFound();
        }

        [HttpGet]
        public IActionResult GetAllTiendas()
        {
            var tiendas = _tiendaService.GetAllTiendas();
            return Ok(tiendas);
        }

        [HttpPost]
        public async Task<IActionResult> AddTienda([FromBody] TiendaDTO tiendaDto)
        {
            var tiendaId = await _tiendaService.AddTienda(tiendaDto);
            return CreatedAtAction(nameof(GetTiendaById), new { tiendaId = tiendaId }, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTienda(UpdateTiendaDTO updateTiendaDTO)
        {
            var response = await _tiendaService.UpdateTienda(updateTiendaDTO);

            return response
                ? Ok()
                : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTienda([FromQuery] int tiendaId)
        {
            var response = await _tiendaService.DeleteTienda(tiendaId);
            return response
                ? Ok()
                : BadRequest();
        }
    }
}
