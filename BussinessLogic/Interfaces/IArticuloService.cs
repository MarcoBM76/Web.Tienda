using BussinessLogic.Features.Articulos.DTO_s;

namespace BussinessLogic.Interfaces
{
    public interface IArticuloService
    {
       Task<ArticuloDTO?> GetArticuloByIdAsync(int articuloId);
       IEnumerable<ArticuloDTO> GetAllArticulos();
       Task<int> AddArticuloAsync(AddArticuloDTO articuloDTO);
       Task<bool> UpdateArticuloAsync(UpdateArticuloDTO articuloDTO);
       Task<bool> DeleteArticuloAsync(int articuloId);

    }
}
