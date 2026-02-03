using BussinessLogic.Features.Articulos.DTO_s;
using BussinessLogic.Features.ArticuloTienda.DTO_s;
using BussinessLogic.Features.Tienda.DTO_s;
using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using Entities;

namespace BussinessLogic.Features.ArticuloTienda
{
    public class ArticuloTiendaService : IArticuloTiendaService
    {
        private IArticuloTiendaRepository _articuloTiendaRepository;
        public ArticuloTiendaService(IArticuloTiendaRepository articuloTiendaRepository)
        {
            _articuloTiendaRepository = articuloTiendaRepository;
        }

        public async Task<int> AddArticuloTienda(AddArticuloTiendaDTO addArticuloTienda)
        {
            var articuloTienda = await _articuloTiendaRepository.AddArticuloTienda(new ArticuloTiendum
            {
                Id = addArticuloTienda.Id,
                IdArticulo = addArticuloTienda.IdArticulo,
                IdTienda = addArticuloTienda.IdTienda,
                Fecha = addArticuloTienda.Fecha
            });
            return articuloTienda.Id;
        }

        public async Task<bool> DeleteArticuloTienda(int id)
        {
            var articuloTienda = await _articuloTiendaRepository.GetArticuloTienda(id);
            
            if (articuloTienda == null)
            {
                return false;
            }

            return await _articuloTiendaRepository.DeleteArticuloTienda(articuloTienda);
        }

        public IEnumerable<ArticuloTiendaDTO> GetAllArticuloTienda()
        {
            return _articuloTiendaRepository.GetAllArticuloTienda().Select(articuloTienda => new ArticuloTiendaDTO
            {
                Id = articuloTienda.Id,
                ArticuloId = articuloTienda.IdArticulo,
                IdTienda = articuloTienda.IdTienda,
                Fecha = articuloTienda.Fecha ?? DateTime.MinValue,
                Articulo = articuloTienda.IdArticuloNavigation != null ? new ArticuloDTO
                {
                    ArticuloId = articuloTienda.IdArticuloNavigation.ArticuloId,
                    Codigo = articuloTienda.IdArticuloNavigation.Codigo,
                    Descripcion = articuloTienda.IdArticuloNavigation.Descripcion,
                    Precio = articuloTienda.IdArticuloNavigation.Precio,
                    Imagen = Convert.ToBase64String(articuloTienda.IdArticuloNavigation.Imagen),
                    Stock = articuloTienda.IdArticuloNavigation.Stock
                } : null,
                Tienda = articuloTienda.IdTiendaNavigation != null ? new TiendaDTO
                {
                    TiendaId = articuloTienda.IdTiendaNavigation.TiendaId,
                    Direccion = articuloTienda.IdTiendaNavigation.Direccion,
                    Sucursal = articuloTienda.IdTiendaNavigation.Sucursal,
                } : null
            });
        }

        public async Task<ArticuloTiendaDTO?> GetArticuloTienda(int id)
        {
            var articuloTienda = await _articuloTiendaRepository.GetArticuloTienda(id);
            if (articuloTienda == null)
            {
                return null;
            }
            return new ArticuloTiendaDTO
            {
                Id = articuloTienda.Id,
                ArticuloId = articuloTienda.IdArticulo,
                IdTienda = articuloTienda.IdTienda,
                Fecha = articuloTienda.Fecha ?? DateTime.MinValue,
                Articulo = articuloTienda.IdArticuloNavigation != null ? new ArticuloDTO
                {
                    ArticuloId = articuloTienda.IdArticuloNavigation.ArticuloId,
                    Codigo = articuloTienda.IdArticuloNavigation.Codigo,
                    Descripcion = articuloTienda.IdArticuloNavigation.Descripcion,
                    Precio = articuloTienda.IdArticuloNavigation.Precio,
                    Imagen = Convert.ToBase64String(articuloTienda.IdArticuloNavigation.Imagen!),
                    Stock = articuloTienda.IdArticuloNavigation.Stock

                } : null,
                Tienda = articuloTienda.IdTiendaNavigation != null ? new TiendaDTO
                {
                    Direccion = articuloTienda.IdTiendaNavigation.Direccion,
                    Sucursal = articuloTienda.IdTiendaNavigation.Sucursal,

                } : null
            };
        }

        public Task<bool> UpdateArticuloTienda(UpdateArticuloTiendaDTO updateArticuloTienda)
        {
            return _articuloTiendaRepository.UpdateArticuloTienda(new ArticuloTiendum
            {
                Id = updateArticuloTienda.Id,
                IdArticulo = updateArticuloTienda.IdArticulo,
                IdTienda = updateArticuloTienda.IdTienda,
                Fecha = updateArticuloTienda.Fecha
            });
        }
    }
}
