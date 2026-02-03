using BussinessLogic.Features.Tienda.DTO_s;
using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using Entities;

namespace BussinessLogic.Features.Tienda
{
    public class TiendaService : ITiendaService
    {
        private readonly ITiendaRepository _tiendaRepository;

        public TiendaService(ITiendaRepository tiendaRepository)
        {
            _tiendaRepository = tiendaRepository;
        }

        public async Task<int> AddTienda(TiendaDTO tiendaDto)
        {
          var tiendaId = await _tiendaRepository.AddTienda(new Tiendum
            {
                Sucursal = tiendaDto.Sucursal,
                Direccion = tiendaDto.Direccion
            });

            return tiendaId;
        }

        public async Task<bool> DeleteTienda(int tiendaId)
        {
           var tienda = await _tiendaRepository.GetTiendaById(tiendaId);
            if(tienda == null)
            {
                return false;
            }
            return await _tiendaRepository.DeleteTienda(tienda);
        }

        public IEnumerable<TiendaDTO> GetAllTiendas()
        {
           return _tiendaRepository.GetAllTienda().Select(tienda => new TiendaDTO
            {
                TiendaId = tienda.TiendaId,
                Sucursal = tienda.Sucursal,
                Direccion = tienda.Direccion
            });
        }

        public async Task<TiendaDTO?> GetTiendaById(int tiendaId)
        {
            var tienda = await _tiendaRepository.GetTiendaById(tiendaId);
            
            if (tienda == null)
            {
                throw new Exception("Tienda no encontrada");
            }

            return (new TiendaDTO
            {
                Sucursal = tienda.Sucursal,
                Direccion = tienda.Direccion
            });
        }

        public async Task<bool> UpdateTienda(UpdateTiendaDTO updateTiendaDTO)
        {
            return await _tiendaRepository.UpdateTienda(new Tiendum
            {
                TiendaId = updateTiendaDTO.TiendaId,
                Sucursal = updateTiendaDTO.Sucursal,
                Direccion = updateTiendaDTO.Direccion
            });
        }
    }
}
