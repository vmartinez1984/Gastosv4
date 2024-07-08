namespace gastosv4.Dtos
{
    public class SubcategoriaDto
    {
        public string Id { get; set; }

        public string Guid { get; set; }

        public string Nombre { get; set; }

        public decimal Cantidad { get; set; }

        public string Categoria { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public bool EsPrimario { get; set; }
    }
}