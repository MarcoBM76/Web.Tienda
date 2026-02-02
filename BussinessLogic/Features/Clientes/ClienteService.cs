using BussinessLogic.Features.Clientes.DTO_s;
using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using Entities;
using System.Threading.Tasks;

namespace BussinessLogic.Features.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<int> AddCliente(AddClienteDTO cliente)
        {
            return _clienteRepository.AddCliente(new Cliente
            {
                Nombre = cliente.Nombre,
                ApellidoP = cliente.ApellidoP,
                ApellidoM = cliente.ApellidoM,
                Direccion = cliente.Direccion
            });
        }
        public async Task<ClienteDTO?> GetCliente(int clienteId)
        {
            var cliente = await _clienteRepository.GetClienteById(clienteId);

            if (cliente == null)
            {
                return null;
            }   

            return new ClienteDTO
            {
                Nombre = cliente.Nombre,
                ApellidoP = cliente.ApellidoP,
                ApellidoM = cliente.ApellidoM,
                Direccion = cliente.Direccion
            };
        }

        public async Task<bool> UpdateCliente(UpdateClienteDTO cliente)
        {
            return await _clienteRepository.UpdateCliente(new Cliente
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                ApellidoP = cliente.ApellidoP,
                ApellidoM = cliente.ApellidoM,
                Direccion = cliente.Direccion
            });

        }

        public async Task<bool> DeleteCliente(int clienteId)
        {
            var cliente = await _clienteRepository.GetClienteById(clienteId);

            if (cliente == null)
            {
                return false;
            }
            return  await _clienteRepository.DeleteCliente(cliente);

        }

        IEnumerable<ClienteDTO> IClienteService.GetAllCliente()
        {
            return _clienteRepository.GetAllClientes().Select(cliente => new ClienteDTO
            {
                Nombre = cliente.Nombre,
                ApellidoP = cliente.ApellidoP,
                ApellidoM = cliente.ApellidoM,
                Direccion = cliente.Direccion
            });
        }
    }
}
