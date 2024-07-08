using gastosv4.Entidades;
using MongoDB.Driver;

namespace gastosv4.Repositorios
{
    public class CategoriaRepositorio
    {
        private readonly IMongoCollection<Categoria> _collection;

        public CategoriaRepositorio(IConfiguration configurations)
        {
            var mongoClient = new MongoClient(configurations.GetConnectionString("mongoDb"));
            var mongoDatabase = mongoClient.GetDatabase(configurations.GetConnectionString("mongoDbNombre"));
            _collection = mongoDatabase.GetCollection<Categoria>("Subcategorias");
        }

        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            List<Categoria> lista;
           
            lista = (await _collection.FindAsync(_ => true)).ToList();

            return lista;
        }
    }
}