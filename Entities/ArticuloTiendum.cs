using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class ArticuloTiendum
{
    public int Id { get; set; }

    public int? IdArticulo { get; set; }

    public int? IdTienda { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Articulo? IdArticuloNavigation { get; set; }

    public virtual Tiendum? IdTiendaNavigation { get; set; }
}
