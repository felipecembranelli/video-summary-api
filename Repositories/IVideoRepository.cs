
namespace OpenAiVideoSummary.Api.Repository
{
    public interface IVideoRepository<Video>
    {
        Task<List<Video>> GetAllVideosByChannelIdAsync(string channelId);
    }
}