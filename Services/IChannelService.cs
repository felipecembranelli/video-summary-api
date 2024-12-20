using OpenAiVideoSummary.Api.Model;

namespace OpenAiVideoSummary.Api.Service
{
    public interface IChannelService
    {
        Task CreateChannelAsync(Channel channel);
        Task DeleteChannelAsync(string id);
        Task<List<Channel>> GetAllChannelsAsync();
        Task<Channel> GetChannelByIdAsync(string id);
        Task UpdateChannelAsync(string id, Channel channel);
        Task<List<Video>> GetVideosByChannelIdAsync(string channelId);
    }
}