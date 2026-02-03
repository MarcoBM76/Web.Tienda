using DataAccess.Context;
using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ArticuloTiendarepository : IArticuloTiendaRepository
    {
        private TiendaDbContext _context;
        public ArticuloTiendarepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<ArticuloTiendum> AddArticuloTienda(ArticuloTiendum articuloTiendum)
        {
            await _context.AddAsync(articuloTiendum);
            await _context.SaveChangesAsync();
            return articuloTiendum;
        }

        public async Task<bool> DeleteArticuloTienda(ArticuloTiendum articuloTiendum)
        {
            await Task.Run(() => { _context.ArticuloTienda.Remove(articuloTiendum); });
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<ArticuloTiendum> GetAllArticuloTienda()
        {
            return _context.ArticuloTienda
                .Include(ca => ca.IdArticuloNavigation)
                .Include(ca => ca.IdTiendaNavigation)
                .ToList();

        }

        public async Task<ArticuloTiendum?> GetArticuloTienda(int id)
        {
            return await _context.ArticuloTienda.Include(ca => ca.IdArticuloNavigation)
                .Include(ca => ca.IdTiendaNavigation)
                .FirstOrDefaultAsync(ca => ca.Id == id);
        }

        public async Task<bool> UpdateArticuloTienda(ArticuloTiendum articuloTiendum)
        {
           var contextArticuloTienda = await _context.ArticuloTienda.FindAsync(articuloTiendum.Id);
              if (contextArticuloTienda == null)
            {
                return false;
            }
                contextArticuloTienda.IdArticulo = articuloTiendum.IdArticulo;
                contextArticuloTienda.IdTienda = articuloTiendum.IdTienda;
                contextArticuloTienda.Fecha = articuloTiendum.Fecha;
                await _context.SaveChangesAsync();
                return true;
        }
    }
}
