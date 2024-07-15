using gastosv4.Entidades;
using MongoDB.Bson;
using MongoDB.Driver;

namespace gastosv4.Repositorios
{
    public class SubcategoriaRepositorio
    {
        private readonly IMongoCollection<Subcategoria> _collection;

        public SubcategoriaRepositorio(IConfiguration configurations)
        {
            var mongoClient = new MongoClient(configurations.GetConnectionString("mongoDb"));
            var mongoDatabase = mongoClient.GetDatabase(configurations.GetConnectionString("mongoDbNombre"));
            _collection = mongoDatabase.GetCollection<Subcategoria>("Subcategorias");
        }

        public async Task<List<Subcategoria>> ObtenerTodosAsync()
        {
            List<Subcategoria> list;
            FilterDefinition<Subcategoria> filter;

            filter = Builders<Subcategoria>.Filter.Eq(x => x.EstaActivo, true);
            list = (await _collection.FindAsync(x => x.EstaActivo == true)).ToList();

            return list.OrderByDescending(x => x.FechaDeRegistro).ToList();
        }

        public async Task ActualizarAsync(Subcategoria item)
        {
            await _collection.ReplaceOneAsync(x => x._id == item._id, item);
        }

        public async Task<Subcategoria> ObtenerAsync(string id)
        {

            Subcategoria item;
            // FilterDefinition<Subcategoria> filter;
            // if (id.Length == 36) //a4ed734e-411a-494a-8190-6e3baf96a215
            //     filter = Builders<Subcategoria>.Filter.Eq("Guid", id);
            // else
            //     filter = Builders<Subcategoria>.Filter.Eq("Id", id);

            item = (await _collection.FindAsync(
                new BsonDocument("$or", new BsonArray
                {
                    new BsonDocument("Id", id),
                    new BsonDocument("Guid", id)
                })
            )).FirstOrDefault();

            return item;
        }

        public async Task<string> AgregarAsync(Subcategoria subcategoria)
        {
            subcategoria.Id = await ObtenerIdAscyn();

            await _collection.InsertOneAsync(subcategoria);

            return subcategoria.Id;
        }

        private async Task<string> ObtenerIdAscyn()
        {
            //Subcategoria subcategoria;
            //FilterDefinition<Subcategoria> filter;

            //filter = Builders<Subcategoria>.Filter
            var id = await _collection.CountDocumentsAsync(_ => true);
            id = id++;

            return id.ToString();
        }
    }
}