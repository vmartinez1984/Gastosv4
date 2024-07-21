using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gastosv4.Entidades
{
    public class Periodo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Id { get; set; }

        public string Guid { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public VersionDePeriodo Version { get; set; }

        public List<DetalleDePeriodo> Detalles { get; set; }

        public bool EstaActivo { get; set; } = true;
    }

    public class DetalleDePeriodo
    {
        public Detalle Detalle{ get; set; }

        public List<MovimientoPeriodo> Movimientos { get; set; } = new List<MovimientoPeriodo>();
    }

    public class MovimientoPeriodo
    {
        public decimal Cantidad { get; set; }

        public string Guid { get; set; }

        public string Nota { get; set; }
    }
}