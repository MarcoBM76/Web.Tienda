using Entities;

namespace DataAccess.Interfaces
{
    public interface ITiendaRepository
    {
        Task<Tiendum?> GetTiendaById(int id);
        IEnumerable<Tiendum> GetAllTienda();
        Task<int> AddTienda(Tiendum tienda);
        Task<bool> UpdateTienda(Tiendum tienda);
        Task<bool> DeleteTienda(Tiendum tienda);
    }
}
