using BussinessLogic.Features.Clientes.DTO_s;
using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
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

        [HttpGet(Name = "GetCliente")]
        public ActionResult<Cliente> Get()
        {
            return _clienteRepository.GetCliente(1) != null
                ? Ok(_clienteRepository.GetCliente(1))
                : NotFound();
        }
    }
}
