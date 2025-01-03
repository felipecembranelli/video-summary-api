using System.Collections.Generic;
using System.Threading.Tasks;
using OpenAiVideoSummary.Api.Model;
using OpenAiVideoSummary.Api.Repository;

namespace OpenAiVideoSummary.Api.Service
{
    /// <summary>
    /// Represents a service for managing channels.
    /// </summary>
    public class ChannelService : IChannelService
    {
        private readonly IBaseRepository<Channel> _channelRepository;
        private readonly IVideoRepository<Video> _videoRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelService"/> class.
        /// </summary>
        /// <param name="channelRepository">The channel repository.</param>
        public ChannelService(IBaseRepository<Channel> channelRepository, IVideoRepository<Video> videoRepository)
        {
            _channelRepository = channelRepository;
            _videoRepository = videoRepository;
        }

        /// <summary>
        /// Gets all channels asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of channels.</returns>
        public async Task<List<Channel>> GetAllChannelsAsync()
        {
            // changed test

            //return await _channelRepository.GetAllAsync();
            return null;
        }

        /// <summary>
        /// Gets a channel by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the channel with the specified ID.</returns>
        public async Task<Channel> GetChannelByIdAsync(string id)
        {
            return await _channelRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Gets a list of videos by channel ID asynchronously.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the channel with the specified ID.</returns>
        public async Task<List<Video>> GetVideosByChannelIdAsync(string channelId)
        {
            return await _videoRepository.GetAllVideosByChannelIdAsync(channelId);
        }

        /// <summary>
        /// Creates a new channel asynchronously.
        /// </summary>
        /// <param name="channel">The channel to create.</param>
        public async Task CreateChannelAsync(Channel channel)
        {
            await _channelRepository.CreateAsync(channel);
        }

        /// <summary>
        /// Updates a channel asynchronously.
        /// </summary>
        /// <param name="id">The ID of the channel to update.</param>
        /// <param name="channel">The updated channel.</param>
        public async Task UpdateChannelAsync(string id, Channel channel)
        {
            await _channelRepository.UpdateAsync(id, channel);
        }

        /// <summary>
        /// Deletes a channel asynchronously.
        /// </summary>
        /// <param name="id">The ID of the channel to delete.</param>
        public async Task DeleteChannelAsync(string id)
        {
            await _channelRepository.DeleteAsync(id);
        }

        // You can add additional methods specific to the Channel service here
    }
}

