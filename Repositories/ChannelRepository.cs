using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OpenAiVideoSummary.Api.Model;

namespace OpenAiVideoSummary.Api.Repository
{
    public class ChannelRepository : BaseRepository<Channel>
    {
        

        public ChannelRepository(IOptions<DatabaseSettings> databaseSettings) 
            : base(databaseSettings, "channels")
        {
        }

        // You can add additional methods specific to the Channel repository here

        
    }
}

