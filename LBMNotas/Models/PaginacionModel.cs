namespace LBMNotas.Models
{
    public class PaginacionModel
    {
        public int PaginaActual { get;set; }
        public int TotalRegistros { get; set; }
        public int RegistrosPorPagina { get; set; }
        public RouteValueDictionary ValoresQueryString { get; set; }
    }
}
