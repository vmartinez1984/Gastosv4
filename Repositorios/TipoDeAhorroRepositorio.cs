using Gastosv4.Entidades;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gastosv4.Repositorios
{
    public class TipoDeAhorroRepositorio
    {
        private readonly IMongoCollection<TipoDeAhorro> _collection;

        public TipoDeAhorroRepositorio(IConfiguration configurations)
        {
            var mongoClient = new MongoClient(configurations.GetConnectionString("mongoDb"));
            var mongoDatabase = mongoClient.GetDatabase(configurations.GetConnectionString("mongoDbNombre"));
            _collection = mongoDatabase.GetCollection<TipoDeAhorro>("TipoDeAhorro");
        }

        public async Task<List<TipoDeAhorro>> ObtenerTodosAsync()
        {
            List<TipoDeAhorro> lista;

            lista = (await _collection.FindAsync(_ => true)).ToList();

            return lista;
        }

        public async Task<TipoDeAhorro> ObtenerAsync(string id)
        {

            TipoDeAhorro entidad;

            entidad = (await _collection.FindAsync(
                new BsonDocument("$or", new BsonArray
                {
                    new BsonDocument("Id", id),
                    new BsonDocument("Guid", id)
                })
            )).FirstOrDefault();

            return entidad;
        }

        public async Task<string> AgregarAsync(TipoDeAhorro item)
        {
            item.Id = await ObtenerIdAscyn();

            await _collection.InsertOneAsync(item);

            return item.Id;
        }

        private async Task<string> ObtenerIdAscyn()
        {
            var id = await _collection.CountDocumentsAsync(_ => true);
            id = id + 1;

            return id.ToString();
        }

        public async Task ActualizarAsync(TipoDeAhorro item)
        {
            await _collection.ReplaceOneAsync(x => x._id == item._id, item);
        }

        public async Task BorrarAsync(string id)
        {
            TipoDeAhorro item;

            item = await ObtenerAsync(id);
            item.EstaActivo = false;
            await _collection.ReplaceOneAsync(x => x._id == item._id, item);
        }
    }
}