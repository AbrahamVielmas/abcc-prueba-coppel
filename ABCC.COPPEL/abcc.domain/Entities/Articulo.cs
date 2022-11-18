namespace abcc.domain.Entities
{
    public class Articulo
    {
        public int Id { get; set; }
        public int Sku { get; set; }
        public string NombreArticulo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int IdDepartamento{ get; set; }
        public int IdClase{ get; set; }
        public int IdFamilia{ get; set; }
        public DateTime FechaAlta { get; set; }
        public int Stock { get; set; }
        public int Cantidad { get; set; }
        public int Descontinuado { get; set; }
        public DateTime FechaBaja { get; set; }
    }

}
