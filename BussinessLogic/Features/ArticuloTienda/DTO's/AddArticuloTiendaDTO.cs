using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Features.ArticuloTienda.DTO_s
{
    public class AddArticuloTiendaDTO
    {
        public int Id { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdTienda { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
