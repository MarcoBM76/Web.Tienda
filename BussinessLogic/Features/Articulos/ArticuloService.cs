using BussinessLogic.Features.Articulos.DTO_s;
using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Entities;

namespace BussinessLogic.Features.Articulos
{
    public class ArticuloService : IArticuloService
    {
        private IArticuloRepository _articuloRepository;

        public ArticuloService(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public  async Task<int> AddArticuloAsync(AddArticuloDTO articuloDTO)
        {
           var articuloId = await _articuloRepository.AddArticulo(new Articulo
            {
                Codigo = articuloDTO.Codigo,
                Descripcion = articuloDTO.Descripcion,
                Precio = articuloDTO.Precio,
                Imagen = ConvertBase64ToByteArray(articuloDTO.Imagen!),
                Stock = articuloDTO.Stock
            }, articuloDTO.TiendaId);
            return articuloId;
        }

        public async Task<bool> DeleteArticuloAsync(int articuloId)
        {
            var articulo = await _articuloRepository.GetArticuloById(articuloId);
            if (articulo == null)
            {
                return false;
            }
            return await _articuloRepository.DeleteArticulo(articulo);
        }


        public IEnumerable<ArticuloDTO> GetAllArticulos()
        {
            return _articuloRepository.GetAllArticulos().Select(articulo => new ArticuloDTO
            {
                ArticuloId = articulo.ArticuloId,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio,
                Imagen = Convert.ToBase64String(articulo.Imagen!),
                Stock = articulo.Stock
            });
        }

        public async Task<ArticuloDTO?> GetArticuloByIdAsync(int articuloId)
        {
            var articulo = await _articuloRepository.GetArticuloById(articuloId);

            if (articulo == null)
            {
                return null;
            }

            return new ArticuloDTO
            {
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio,
                Imagen = Convert.ToBase64String(articulo.Imagen!),
                Stock = articulo.Stock
            };
        }

        public Task<bool> UpdateArticuloAsync(UpdateArticuloDTO articuloDTO)
        {
            return _articuloRepository.UpdateArticulo(new Articulo
            {
                ArticuloId = articuloDTO.ArticuloId,
                Codigo = articuloDTO.Codigo,
                Descripcion = articuloDTO.Descripcion,
                Precio = articuloDTO.Precio,
                Imagen = ConvertBase64ToByteArray(articuloDTO.Imagen!),
                Stock = articuloDTO.Stock
            });

        }

        private byte[]? ConvertBase64ToByteArray(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                return new byte[] { };
            }
            var base64Part = base64String.Contains(",")
                             ? base64String.Split(',')[1]
                             : base64String;
            return Convert.FromBase64String(base64Part);
        }
    }
}
