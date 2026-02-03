using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Features.ClienteArticulos.DTO_s
{
    public class UpdateClienteArticuloDTO
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? ArticuloId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
