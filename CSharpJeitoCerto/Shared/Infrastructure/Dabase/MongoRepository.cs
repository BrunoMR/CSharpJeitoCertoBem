using MongoDB.Driver;
using CSharpJeitoCerto.Shared.Domain;
using Microsoft.Extensions.Options;

namespace CSharpJeitoCerto.Shared.Infrastructure.Database
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoClient mongoClient, IOptions<DatabaseSettings> databaseSettings, string collectionName)
        {
            var database = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            var id = typeof(T).GetProperty("Id").GetValue(entity);
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }
    }
}