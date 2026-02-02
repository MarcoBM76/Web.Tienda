using Entities;

namespace DataAccess.Interfaces
{
    public interface IClienteArticuloRepository
    {
        Task<ClienteArticulo?> GetClienteArticulo(int id);
        IEnumerable<ClienteArticulo> GetAllClienteArticulo();
        Task<ClienteArticulo> AddClienteArticulo(ClienteArticulo clienteArticulo);
        Task<bool> DeleteClienteArticulo(ClienteArticulo clienteArticulo);
        Task<bool> UpdateClienteArticulo(ClienteArticulo clienteArticulo);

    }
}
