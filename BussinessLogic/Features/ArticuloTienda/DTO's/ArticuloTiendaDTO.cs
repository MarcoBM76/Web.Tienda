using BussinessLogic.Features.Articulos.DTO_s;
using BussinessLogic.Features.Tienda.DTO_s;

namespace BussinessLogic.Features.ArticuloTienda.DTO_s
{
    public class ArticuloTiendaDTO
    {
        public int Id { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdTienda { get; set; }
        public DateTime? Fecha { get; set; }
        public TiendaDTO? Tiendum { get; set; }
        public ArticuloDTO? Articulo { get; set; }
    }
}
