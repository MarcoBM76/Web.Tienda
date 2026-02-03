using Entities;

namespace DataAccess.Interfaces
{
    public interface IArticuloTiendaRepository
    {
        Task<ArticuloTiendum?> GetArticuloTienda(int id);
        IEnumerable<ArticuloTiendum> GetAllArticuloTienda();
        Task<ArticuloTiendum> AddArticuloTienda(ArticuloTiendum articuloTiendum);
        Task<bool> DeleteArticuloTienda(ArticuloTiendum articuloTiendum);
        Task<bool> UpdateArticuloTienda(ArticuloTiendum articuloTiendum);

    }
}
