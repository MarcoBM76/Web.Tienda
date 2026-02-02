using BussinessLogic.Features.Articulos.DTO_s;
using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet("{articuloId}")]
        public async Task<IActionResult> GetArticuloById([FromRoute] int articuloId)
        {
            var articulos = await  _articuloService.GetArticuloByIdAsync(articuloId);

            return articulos != null
                ? Ok(articulos)
                : NotFound();
        }

        [HttpGet]
        public IActionResult GetAllArticulos()
        {
            var articulos = _articuloService.GetAllArticulos();
            return Ok(articulos);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticulo([FromBody] AddArticuloDTO articuloDto)
        {
            var articulo = await _articuloService.AddArticuloAsync(articuloDto);
            return CreatedAtAction(nameof(GetArticuloById), new { articuloId = articulo }, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticulo(UpdateArticuloDTO updateArticuloDTO)
        {
            var response = await _articuloService.UpdateArticuloAsync(updateArticuloDTO);
            return response
                ? Ok()
                : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteArticulo([FromQuery] int articuloId)
        {
            var response = await _articuloService.DeleteArticuloAsync(articuloId);
            return response
                ? Ok()
                : BadRequest();
        }
    }
}
