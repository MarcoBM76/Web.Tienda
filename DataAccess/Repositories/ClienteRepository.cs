using DataAccess.Context;
using DataAccess.Interfaces;
using Entities;

namespace DataAccess.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private TiendaDbContext _context;

        public ClienteRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCliente(Cliente cliente)
        {
            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente.ClienteId;
        }

        public async Task<bool> DeleteCliente(Cliente cliente)
        {
            await Task.Run(() => _context.Clientes.Remove(cliente));
            var result =  await _context.SaveChangesAsync();
            return result > 0;
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }

        public async Task<Cliente?> GetClienteById(int clienteId)
        {
            return await _context.Clientes.FindAsync(clienteId);
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var contextCliente = await _context.Clientes.FindAsync(cliente.ClienteId);


            if (contextCliente is null)
            {
                return false;
            }

            contextCliente.Nombre = cliente.Nombre;
            contextCliente.ApellidoP = cliente.ApellidoP;
            contextCliente.ApellidoM = cliente.ApellidoM;
            contextCliente.Direccion = cliente.Direccion;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
