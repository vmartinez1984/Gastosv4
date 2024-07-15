namespace Gastosv4.Dtos
{
    public class VersionDtoIn
    {        
        public string Guid { get; set; }

        public string Nombre { get; set; }

        public List<Detalle> Detalles { get; set; }
    }

    public class Detalle{    

        public string Guid { get; set; }

        public decimal Cantidad { get; set; }

        public string Nombre { get; set; }

        public string AhorroId { get; set; }
    }
}