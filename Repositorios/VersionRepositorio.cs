using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gastosv4.Entidades;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gastosv4.Repositorios
{
    public class VersionRepositorio
    {
        private readonly IMongoCollection<VersionDePeriodo> _collection;

        public VersionRepositorio(IConfiguration configurations)
        {
            var mongoClient = new MongoClient(configurations.GetConnectionString("mongoDb"));
            var mongoDatabase = mongoClient.GetDatabase(configurations.GetConnectionString("mongoDbNombre"));
            _collection = mongoDatabase.GetCollection<VersionDePeriodo>("Versiones");
        }

        public async Task<List<VersionDePeriodo>> ObtenerTodosAsync()
        {
            List<VersionDePeriodo> lista;

            lista = (await _collection.FindAsync(_ => true)).ToList();

            return lista;
        }

        public async Task<VersionDePeriodo> ObtenerAsync(string id)
        {

            VersionDePeriodo entidad;

            entidad = (await _collection.FindAsync(
                new BsonDocument("$or", new BsonArray
                {
                    new BsonDocument("Id", id),
                    new BsonDocument("Guid", id)
                })
            )).FirstOrDefault();

            return entidad;
        }

        public async Task<string> AgregarAsync(VersionDePeriodo item)
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

        public async Task ActualizarAsync(VersionDePeriodo item)
        {
            await _collection.ReplaceOneAsync(x => x._id == item._id, item);
        }        
    }
}