using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Features.Tienda.DTO_s
{
    public class UpdateTiendaDTO
    {
        public int TiendaId { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
    }
}
