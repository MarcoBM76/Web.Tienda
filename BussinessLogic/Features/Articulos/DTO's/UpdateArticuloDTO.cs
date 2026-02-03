using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Features.Articulos.DTO_s
{
    public class UpdateArticuloDTO
    {
        public int ArticuloId { get; set; }
        public string Codigo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Precio { get; set; }
        public string? Imagen { get; set; }
        public int Stock { get; set; }
    }
}
