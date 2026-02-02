using BussinessLogic.Features.ArticuloTienda.DTO_s;
using BussinessLogic.Features.ClienteArticulos.DTO_s;
namespace BussinessLogic.Interfaces
{
    public interface IArticuloTiendaService
    {
        Task<ArticuloTiendaDTO?> GetArticuloTienda(int id);
        IEnumerable<ArticuloTiendaDTO> GetAllArticuloTienda();
        Task<int> AddArticuloTienda(AddArticuloTiendaDTO addArticuloTienda);
        Task<bool> DeleteArticuloTienda(int id);
        Task<bool> UpdateArticuloTienda(UpdateArticuloTiendaDTO updateArticuloTienda);
    }
}
