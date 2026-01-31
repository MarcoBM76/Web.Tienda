using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Articulo
{
    public int ArticuloId { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Precio { get; set; }

    public string? Imagen { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; set; } = new List<ArticuloTiendum>();

    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; } = new List<ClienteArticulo>();
}
