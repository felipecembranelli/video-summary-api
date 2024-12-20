using OpenAiVideoSummary.Api.Model;

namespace OpenAiVideoSummary.Api.Service
{
    public interface IVideoService
    {
        Task CreateVideoAsync(Video video);
        Task DeleteVideoAsync(string id);
        Task<List<Video>> GetAllVideosAsync();
        Task<Video> GetVideoByIdAsync(string id);
        Task UpdateVideoAsync(string id, Video video);
    }
}