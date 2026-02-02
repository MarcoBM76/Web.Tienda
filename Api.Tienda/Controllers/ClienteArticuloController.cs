using BussinessLogic.Features.ClienteArticulos.DTO_s;
using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteArticuloController : ControllerBase
    {
        private IClienteArticuloService _clienteArticuloService;
        public ClienteArticuloController(IClienteArticuloService clienteArticuloService)
        {
            _clienteArticuloService = clienteArticuloService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteArticuloId([FromRoute] int id)
        {
            var clienteArticulo = await _clienteArticuloService.GetClienteArticulo(id);
            return clienteArticulo != null
                ? Ok(clienteArticulo)
                : NotFound();
        }
        [HttpGet]
        public IActionResult GetAllClienteArticulo()
        {
            var clienteArticulos = _clienteArticuloService.GetAllClienteArticulo();
            return Ok(clienteArticulos);
        }
        [HttpPost]
        public async Task<IActionResult> AddClienteArticulo([FromBody] AddClienteArticuloDTO clienteArticulo)
        {
            var clienteArticuloId = await _clienteArticuloService.AddClienteArticulo(clienteArticulo);
            return CreatedAtAction(nameof(GetClienteArticuloId), new { id = clienteArticuloId }, clienteArticuloId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteArticulo([FromRoute] int id)
        {
            var result = await _clienteArticuloService.DeleteClienteArticulo(id);
            return result
                ? NoContent()
                : NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateClienteArticulo([FromBody] UpdateClienteArticuloDTO clienteArticulo)
        {
            var result = await _clienteArticuloService.UpdateClienteArticulo(clienteArticulo);
            return result
                ? NoContent()
                : NotFound();
        }
    }
}
