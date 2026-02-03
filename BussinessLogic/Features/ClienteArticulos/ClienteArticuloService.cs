using BussinessLogic.Features.Articulos.DTO_s;
using BussinessLogic.Features.ClienteArticulos.DTO_s;
using BussinessLogic.Features.Clientes.DTO_s;
using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using Entities;
using System.Net.Security;

namespace BussinessLogic.Features.ClienteArticulos
{
    public class ClienteArticuloService : IClienteArticuloService
    {
        private IClienteArticuloRepository _clienteArticuloRepository;

        public ClienteArticuloService(IClienteArticuloRepository clienteArticuloRepository)
        {
            _clienteArticuloRepository = clienteArticuloRepository;
        }

        public async Task<int> AddClienteArticulo(AddClienteArticuloDTO addClienteArticulo)
        {
            var clienteArticulo = await _clienteArticuloRepository.AddClienteArticulo(new ClienteArticulo
            {
                IdCliente = addClienteArticulo.ClienteId,
                IdArticulo = addClienteArticulo.ArticuloId,
                Fecha = DateTime.Now
            });
            return clienteArticulo.Id;
        }

        public async Task<bool> DeleteClienteArticulo(int id)
        {
            var clienteArticulo = await _clienteArticuloRepository.GetClienteArticulo(id);
           
            if (clienteArticulo == null)
            {
                return false;
            }
            
            return await _clienteArticuloRepository.DeleteClienteArticulo(clienteArticulo);
        }

        public IEnumerable<ClienteArticuloDTO> GetAllArticuloByClienteId(int clienteId)
        {
            var clienteArticulo = _clienteArticuloRepository.GetAllArticuloByClienteId(clienteId);

            return clienteArticulo.Select(clienteArticulo =>
                new ClienteArticuloDTO
                {
                    Id = clienteArticulo.Id,
                    ArticuloId = clienteArticulo.IdArticuloNavigation!.ArticuloId,
                    Codigo = clienteArticulo.IdArticuloNavigation.Codigo,
                    Descripcion = clienteArticulo.IdArticuloNavigation.Descripcion,
                    Precio = clienteArticulo.IdArticuloNavigation.Precio,
                    Imagen = Convert.ToBase64String(clienteArticulo.IdArticuloNavigation.Imagen!),
                    Stock = clienteArticulo.IdArticuloNavigation.Stock
                });
        }

        public IEnumerable<ClienteArticuloDTO> GetAllClienteArticulo()
        {
            return _clienteArticuloRepository.GetAllClienteArticulo().Select(clienteArticulo => new ClienteArticuloDTO
            {
                Id = clienteArticulo.Id,
                ClienteId = clienteArticulo.IdCliente,
                ArticuloId = clienteArticulo.IdArticulo,
                Fecha = clienteArticulo.Fecha ?? DateTime.MinValue,
                Cliente = clienteArticulo.IdClienteNavigation != null ? new ClienteDTO
                {
                    ClienteId = clienteArticulo.IdClienteNavigation.ClienteId,
                    Nombre = clienteArticulo.IdClienteNavigation.Nombre,
                    ApellidoP = clienteArticulo.IdClienteNavigation.ApellidoP,
                    ApellidoM = clienteArticulo.IdClienteNavigation.ApellidoM,
                    Direccion = clienteArticulo.IdClienteNavigation.Direccion,
                    
                } : null,
                Articulo = clienteArticulo.IdArticuloNavigation != null ? new ArticuloDTO
                {
                    ArticuloId = clienteArticulo.IdArticuloNavigation.ArticuloId,
                    Codigo = clienteArticulo.IdArticuloNavigation.Codigo,
                    Descripcion = clienteArticulo.IdArticuloNavigation.Descripcion,
                    Precio = clienteArticulo.IdArticuloNavigation.Precio,
                    Imagen = Convert.ToBase64String(clienteArticulo.IdArticuloNavigation.Imagen!),
                    Stock = clienteArticulo.IdArticuloNavigation.Stock
                } : null
            });
        }

        public async Task<ClienteArticuloDTO> GetClienteArticulo(int id)
        {
            var clienteArticulo = await _clienteArticuloRepository.GetClienteArticulo(id);
            if (clienteArticulo == null)
            {
                return null;
            }   
            return new ClienteArticuloDTO
            {
                Id = clienteArticulo.Id,
                ClienteId = clienteArticulo.IdCliente,
                ArticuloId = clienteArticulo.IdArticulo,
                Fecha = clienteArticulo.Fecha ?? DateTime.MinValue,
                Cliente = clienteArticulo.IdClienteNavigation != null ? new ClienteDTO
                {
                    ClienteId = clienteArticulo.IdClienteNavigation.ClienteId,
                    Nombre = clienteArticulo.IdClienteNavigation.Nombre,
                    ApellidoP = clienteArticulo.IdClienteNavigation.ApellidoP,
                    ApellidoM = clienteArticulo.IdClienteNavigation.ApellidoM,
                    Direccion = clienteArticulo.IdClienteNavigation.Direccion,
                    
                } : null,
                Articulo = clienteArticulo.IdArticuloNavigation != null ? new ArticuloDTO
                {
                    ArticuloId = clienteArticulo.IdArticuloNavigation.ArticuloId,
                    Codigo = clienteArticulo.IdArticuloNavigation.Codigo,
                    Descripcion = clienteArticulo.IdArticuloNavigation.Descripcion,
                    Precio = clienteArticulo.IdArticuloNavigation.Precio,
                    Imagen = Convert.ToBase64String(clienteArticulo.IdArticuloNavigation.Imagen!),
                    Stock = clienteArticulo.IdArticuloNavigation.Stock
                } : null
            };
        }

        public Task<bool> UpdateClienteArticulo(UpdateClienteArticuloDTO clienteArticulo)
        {
            return _clienteArticuloRepository.UpdateClienteArticulo(new ClienteArticulo
            {
                Id = clienteArticulo.Id,
                IdCliente = clienteArticulo.ClienteId,
                IdArticulo = clienteArticulo.ArticuloId,
                Fecha = clienteArticulo.Fecha
            });
        }
    }
}
