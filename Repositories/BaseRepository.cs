using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OpenAiVideoSummary.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAiVideoSummary.Api.Repository
{
    /// <summary>
    /// Represents a base repository for CRUD operations on a MongoDB collection.
    /// </summary>
    /// <typeparam name="T">The type of the entities in the collection.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected readonly IMongoCollection<T> _collection;
        private readonly ILogger<BaseRepository<T>> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="databaseSettings">The database settings.</param>
        /// <param name="collectionName">The name of the collection.</param>
        public BaseRepository(IOptions<DatabaseSettings> databaseSettings, string collectionName, ILogger<BaseRepository<T>> logger)
        {
            _logger = logger;
            _logger.LogInformation($"Connecting to database: {databaseSettings.Value.ConnectionString}");
            _logger.LogInformation($"Connecting to database: {databaseSettings.Value.DatabaseName}");
            _logger.LogInformation($"Connecting to database: {databaseSettings.Value.CollectionName}");

            var mongoClient = new MongoClient(
               databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        /// <summary>
        /// Gets all entities from the collection.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of entities.</returns>
        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        /// <summary>
        /// Gets an entity by its ID from the collection.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("channelId", id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new entity in the collection.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        /// <summary>
        /// Updates an entity in the collection.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="entity">The updated entity.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);
        }

        /// <summary>
        /// Deletes an entity from the collection.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }
    }
}
