namespace BussinessLogic.Features.Articulos.DTO_s
{
    public class ArticuloDTO
    {
        public int? ArticuloId { get; set; }
        public string Codigo { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int Precio { get; set; }

        public string? Imagen { get; set; }

        public int Stock { get; set; }
    }
}
