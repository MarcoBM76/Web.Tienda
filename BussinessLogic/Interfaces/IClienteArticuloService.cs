using BussinessLogic.Features.Articulos.DTO_s;
using BussinessLogic.Features.ClienteArticulos.DTO_s;
using Entities;

namespace BussinessLogic.Interfaces
{
    public interface IClienteArticuloService
    {
        Task<ClienteArticuloDTO> GetClienteArticulo(int id);
        IEnumerable<ClienteArticuloDTO> GetAllClienteArticulo();
        IEnumerable<ClienteArticuloDTO> GetAllArticuloByClienteId(int clienteId);
        Task<int> AddClienteArticulo(AddClienteArticuloDTO addClienteArticulo);
        Task<bool> DeleteClienteArticulo(int id);
        Task<bool> UpdateClienteArticulo(UpdateClienteArticuloDTO clienteArticulo);
    }
}
