using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Tiendum
{
    public int TiendaId { get; set; }

    public string Sucursal { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; set; } = new List<ArticuloTiendum>();
}
