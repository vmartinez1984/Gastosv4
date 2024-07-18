using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gastosv4.Entidades
{
    public class VersionDePeriodo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Id { get; set; }

        public string Guid { get; set; }

        public string Nombre { get; set; }

        public DateTime? FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; }

        public List<Detalle> Detalles { get; set; } = new List<Detalle>();
    }

    public class Detalle
    {
        public string Guid { get; set; }

        public decimal Cantidad { get; set; }
        
        public string Nombre { get; set; }

        public string AhorroId { get; set; }
    }
}