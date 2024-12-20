using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OpenAiVideoSummary.Api.Model;
using System.Threading.Channels;

namespace OpenAiVideoSummary.Api.Repository
{
    public class VideoRepository : BaseRepository<Video>, IVideoRepository<Video>
    {
        private readonly IMongoCollection<Video> _collection;

        public VideoRepository(IOptions<DatabaseSettings> databaseSettings, ILogger<BaseRepository<Video>> logger) 
            : base(databaseSettings, "videos", logger)
        {
            _collection = base._collection;
        }

        // You can add additional methods specific to the Video repository here

        /// <summary>
        /// Gets an entity by its ID from the collection.
        /// </summary>
        /// <param name="channelId">The ID of the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
        public async Task<List<Video>> GetAllVideosByChannelIdAsync(string channelId)
        {
            return await _collection.Find(Builders<Video>.Filter.Eq("channelId", channelId)).ToListAsync();
        }

    }
}
