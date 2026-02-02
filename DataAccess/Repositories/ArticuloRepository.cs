using DataAccess.Context;
using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private TiendaDbContext _context;
        public ArticuloRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddArticulo(Articulo articulo)
        {
            await _context.Articulos.AddAsync(articulo);
            await _context.SaveChangesAsync();

            return articulo.ArticuloId;
        }

        public async Task<bool> DeleteArticulo(Articulo articulo)
        {
            _context.Articulos.Remove(articulo);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public IEnumerable<Articulo> GetAllArticulos()
        {
            return _context.Articulos.ToList();
        }

        public async Task<Articulo?> GetArticuloById(int articuloId)
        {
            return await _context.Articulos.FindAsync(articuloId);
        }

        public async Task<bool> UpdateArticulo(Articulo articulo)
        {
            var contextArticulo = await _context.Articulos.FindAsync(articulo.ArticuloId);
            if (contextArticulo == null)
            {
                return false;
            }
            contextArticulo.Codigo = articulo.Codigo;
            contextArticulo.Descripcion = articulo.Descripcion;
            contextArticulo.Precio = articulo.Precio;
            contextArticulo.Imagen = articulo.Imagen;
            contextArticulo.Stock = articulo.Stock;
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
