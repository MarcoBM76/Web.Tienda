using DataAccess.Context;
using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ClienteArticuloRepository : IClienteArticuloRepository
    {
        private TiendaDbContext _context;

        public ClienteArticuloRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<ClienteArticulo> AddClienteArticulo(ClienteArticulo clienteArticulo)
        {
            await _context.AddAsync(clienteArticulo);
            await _context.SaveChangesAsync();
            return clienteArticulo;
        }

        public async Task<bool> DeleteClienteArticulo(ClienteArticulo clienteArticulo)
        {
            await Task.Run(() => { _context.ClienteArticulos.Remove(clienteArticulo); });
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<ClienteArticulo> GetAllClienteArticulo()
        {
            return _context.ClienteArticulos
                .Include(ca => ca.IdClienteNavigation)
                .Include(ca => ca.IdArticuloNavigation)
                .ToList();
        }

        public async Task<ClienteArticulo?> GetClienteArticulo(int id)
        {
            return await _context.ClienteArticulos.Include(ca => ca.IdClienteNavigation)
                .Include(ca => ca.IdArticuloNavigation)
                .FirstOrDefaultAsync(ca => ca.Id == id);
        }

        public async Task<bool> UpdateClienteArticulo(ClienteArticulo clienteArticulo)
        {
            var contextClienteArticulo = await _context.ClienteArticulos.FindAsync(clienteArticulo.Id);
           
            if (contextClienteArticulo is null)
            {
                return false;
            }

            contextClienteArticulo.IdCliente = clienteArticulo.IdCliente;
            contextClienteArticulo.IdArticulo = clienteArticulo.IdArticulo;
            contextClienteArticulo.Fecha = clienteArticulo.Fecha;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
