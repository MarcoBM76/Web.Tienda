using Entities;

namespace DataAccess.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetClienteById(int id);
        IEnumerable<Cliente> GetAllClientes();
        Task<int> AddCliente(Cliente cliente);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(Cliente cliente);
    }
}
