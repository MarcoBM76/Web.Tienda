using BussinessLogic.Features.Articulos.DTO_s;
using BussinessLogic.Features.Tienda.DTO_s;

namespace BussinessLogic.Features.ArticuloTienda.DTO_s
{
    public class ArticuloTiendaDTO : ArticuloDTO
    {
        public int Id { get; set; }
        public int? ArticuloId { get; set; }
        public int? IdTienda { get; set; }
        public DateTime? Fecha { get; set; }
        public TiendaDTO? Tienda { get; set; }
        public ArticuloDTO? Articulo { get; set; }
    }
}
