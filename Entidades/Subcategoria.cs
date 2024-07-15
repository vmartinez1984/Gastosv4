using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace gastosv4.Entidades
{
    public class Subcategoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Id { get; set; }

        public string Guid { get; set; }

        public string Nombre { get; set; }

        public decimal  Cantidad { get; set; }

        public string Categoria { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public bool EsPrimario { get; set; }

        public bool EstaActivo { get; set; } = true;
    }
}