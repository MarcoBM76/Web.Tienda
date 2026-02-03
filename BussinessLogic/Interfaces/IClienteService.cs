using BussinessLogic.Features.Clientes.DTO_s;

namespace BussinessLogic.Interfaces
{
    public interface IClienteService
    {
        public Task<ClienteDTO?> GetCliente(int clienteId);
        public IEnumerable<ClienteDTO> GetAllCliente();
        public Task<int> AddCliente(AddClienteDTO cliente);
        public Task<bool> UpdateCliente(UpdateClienteDTO cliente);
        public Task<bool> DeleteCliente(int clienteId);


    }
}
