using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace gastosv4.Entidades
{
    public class Categoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public bool EstaActivo { get; set; }
    }
}