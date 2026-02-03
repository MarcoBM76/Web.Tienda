using BussinessLogic.Features.Clientes.DTO_s;
using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteRepository;

        public ClienteController(IClienteService clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetClienteById([FromRoute] int clienteId)
        {
            var cliente = await _clienteRepository.GetCliente(clienteId);

            return cliente != null
                ? Ok(cliente)
                : NotFound();
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            var clientes = _clienteRepository.GetAllCliente();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] AddClienteDTO cliente)
        {
            var clienteId = await _clienteRepository.AddCliente(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { clienteId = clienteId }, clienteId);
        }

        [HttpPut("{clienteId}")]
        public async Task<IActionResult> UpdateCliente([FromRoute] int clienteId, [FromBody] UpdateClienteDTO cliente)
        {
            cliente.ClienteId = clienteId;
            var response = await _clienteRepository.UpdateCliente(cliente);

            return response
                ? Ok()
                : BadRequest();
        }

        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] int clienteId)
        {
            var response = await _clienteRepository.DeleteCliente(clienteId);
            return response
                ? Ok()
                : NotFound();
        }

    }
}
