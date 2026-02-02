using DataAccess.Context;
using DataAccess.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TiendaRepository : ITiendaRepository
    {
        private readonly TiendaDbContext _context;

        public TiendaRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddTienda(Tiendum tienda)
        {
            await  _context.AddAsync(tienda);
            await  _context.SaveChangesAsync();

            return tienda.TiendaId;
        }

        public async Task<bool> DeleteTienda(Tiendum tienda)
        {
            _context.Tienda.Remove(tienda);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public IEnumerable<Tiendum> GetAllTienda()
        {
            return _context.Tienda.ToList();
        }

        public async Task<Tiendum?> GetTiendaById(int id)
        {
            return await _context.Tienda.FindAsync(id);
        }

        public async Task<bool> UpdateTienda(Tiendum tienda)
        {
            var contextTienda = await _context.Tienda.FindAsync(tienda.TiendaId);

            if(contextTienda is null)
            {
                return false;
            }

            contextTienda.Sucursal = tienda.Sucursal;
            contextTienda.Direccion = tienda.Direccion;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
