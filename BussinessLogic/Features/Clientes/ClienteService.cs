using BussinessLogic.Features.Clientes.DTO_s;
using BussinessLogic.Interfaces;

namespace BussinessLogic.Features.Clientes
{
    public class ClienteService : IClienteService
    {
        public ClienteService()
        {
            
        }

        public Cliente GetCliente(int clienteId)
        {
            return new Cliente { Nombre = "Cliente de ejemplo" };
        }
    }
}
