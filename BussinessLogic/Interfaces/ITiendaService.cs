using BussinessLogic.Features.Tienda.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface ITiendaService
    {
        Task<TiendaDTO?> GetTiendaById(int tiendaId);
        IEnumerable<TiendaDTO> GetAllTiendas();
        Task<int> AddTienda(TiendaDTO tiendaDto);
        Task<bool> UpdateTienda(UpdateTiendaDTO updateTiendaDTO);
        Task<bool> DeleteTienda(int tiendaId);
    }
}