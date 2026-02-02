using Entities;

namespace DataAccess.Interfaces
{
    public interface IArticuloRepository
    {
        Task<Articulo?> GetArticuloById(int articuloId);
        IEnumerable<Articulo> GetAllArticulos();
        Task<int> AddArticulo(Articulo articulo);
        Task<bool> UpdateArticulo(Articulo articulo);
        Task<bool> DeleteArticulo(Articulo articulo);


    }
}
