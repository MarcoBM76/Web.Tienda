using BussinessLogic.Features.Articulos.DTO_s;
using BussinessLogic.Features.Clientes.DTO_s;
using Entities;

namespace BussinessLogic.Features.ClienteArticulos.DTO_s
{
    public class ClienteArticuloDTO
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? ArticuloId { get; set; }
        public DateTime Fecha { get; set; }
        public ClienteDTO? Cliente { get; set; }
        public ArticuloDTO? Articulo { get; set; }

    }
}
