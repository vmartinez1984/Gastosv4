using gastosv4.Entidades;
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

            return list;
        }

        public async Task ActualizarAsync(Subcategoria item)
        {
            await _collection.ReplaceOneAsync(x => x._id == item._id, item);
        }

        public async Task<Subcategoria> ObtenerAsync(string id)
        {

            Subcategoria item;
            FilterDefinition<Subcategoria> filter;
            if (id.Length == 36)
                filter = Builders<Subcategoria>.Filter.Eq("Guid", id);
            else
                filter = Builders<Subcategoria>.Filter.Eq("Id", id);
            item = (await _collection.FindAsync(filter)).FirstOrDefault();

            return item;
        }
    }
}