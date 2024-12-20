using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OpenAiVideoSummary.Api.Model;

namespace OpenAiVideoSummary.Api.Repository
{
    public class ChannelRepository : BaseRepository<Channel>
    {
        

        public ChannelRepository(IOptions<DatabaseSettings> databaseSettings, ILogger<BaseRepository<Channel>> logger) 
            : base(databaseSettings, "channels", logger)
        {
        }

        // You can add additional methods specific to the Channel repository here

        
    }
}

