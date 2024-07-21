using Gastosv4.Entidades;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gastosv4.Repositorios
{
    public class PeriodoRepositorio
    {
        private readonly IMongoCollection<Periodo> _collection;

        public PeriodoRepositorio(IConfiguration configurations)
        {
            var mongoClient = new MongoClient(configurations.GetConnectionString("mongoDb"));
            var mongoDatabase = mongoClient.GetDatabase(configurations.GetConnectionString("mongoDbNombre"));
            _collection = mongoDatabase.GetCollection<Periodo>("Periodos");
        }

        public async Task<Periodo> ObtenerAsync(string periodId)
        {
            Periodo item;

            item = (await _collection.FindAsync(
               new BsonDocument("$or", new BsonArray
               {
                    new BsonDocument("Id", periodId),
                    new BsonDocument("Guid", periodId)
               })
           )).FirstOrDefault();

            return item;
        }

        public async Task<string> AgregarAsync(Periodo entida)
        {
            entida.Id = await ObtenerIdAscyn();
            await _collection.InsertOneAsync(entida);

            return entida.Id;
        }

        private async Task<string> ObtenerIdAscyn()
        {
            var id = await _collection.CountDocumentsAsync(_ => true);
            id = id + 1;

            return id.ToString();
        }

        public async Task<List<Periodo>> ObtenerAsync()
        {
            List<Periodo> list;
            FilterDefinition<Periodo> filter;

            filter = Builders<Periodo>.Filter.Eq(x => x.EstaActivo, true);
            list = (await _collection.FindAsync(x => x.EstaActivo == true)).ToList();

            return list;
        }

        public async Task ActualizarAsync(Periodo periodo)
        {
            await _collection.ReplaceOneAsync(x => x._id == periodo._id, periodo);
        }
    }
}