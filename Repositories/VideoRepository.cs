using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OpenAiVideoSummary.Api.Model;

namespace OpenAiVideoSummary.Api.Repository
{
    public class VideoRepository : BaseRepository<Video>
    {
        public VideoRepository(IOptions<DatabaseSettings> databaseSettings) 
            : base(databaseSettings, "videos")
        {
        }

        // You can add additional methods specific to the Video repository here
    }
}
