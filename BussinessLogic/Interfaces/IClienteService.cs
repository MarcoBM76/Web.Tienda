using BussinessLogic.Features.Clientes.DTO_s;

namespace BussinessLogic.Interfaces
{
    public interface IClienteService
    {
        public Cliente GetCliente(int clienteId);
    }
}
