using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenAiVideoSummary.Api.Model;
using OpenAiVideoSummary.Api.Service;

namespace OpenAiVideoSummary.Api.Controllers
{
    /// <summary>
    /// Controller for managing channels.
    /// </summary>
    [ApiController]
    [Route("api/channels")]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelController"/> class.
        /// </summary>
        /// <param name="channelService">The channel service.</param>
        public ChannelController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        /// <summary>
        /// Gets all channels.
        /// </summary>
        /// <returns>The list of channels.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Channel>>> GetAllChannels()
        {
            var channels = await _channelService.GetAllChannelsAsync();
            return Ok(channels);
        }

        /// <summary>
        /// Gets a channel by its ID.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <returns>The channel with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Channel>> GetChannelById(string id)
        {
            var channel = await _channelService.GetChannelByIdAsync(id);
            if (channel == null)
            {
                return NotFound();
            }
            return Ok(channel);
        }

        /// <summary>
        /// Gets a list of videos by channel ID.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <returns>The channel with the specified ID.</returns>
        [HttpGet("{channelId}/videos")]
        public async Task<ActionResult<List<Video>>> GetVideosByChannelId(string channelId)
        {
            var videos = await _channelService.GetVideosByChannelIdAsync(channelId);

            if (videos == null)
            {
                return NotFound();
            }
            return Ok(videos);
        }

        /// <summary>
        /// Creates a new channel.
        /// </summary>
        /// <param name="channel">The channel to create.</param>
        /// <returns>The created channel.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateChannel([FromBody] Channel channel)
        {
            await _channelService.CreateChannelAsync(channel);
            return CreatedAtAction(nameof(GetChannelById), new { id = channel.ChannelId }, channel);
        }

        /// <summary>
        /// Updates a channel.
        /// </summary>
        /// <param name="id">The ID of the channel to update.</param>
        /// <param name="channel">The updated channel.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChannel(string id, [FromBody] Channel channel)
        {
            var existingChannel = await _channelService.GetChannelByIdAsync(id);
            if (existingChannel == null)
            {
                return NotFound();
            }
            await _channelService.UpdateChannelAsync(id, channel);
            return NoContent();
        }

        /// <summary>
        /// Deletes a channel.
        /// </summary>
        /// <param name="id">The ID of the channel to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChannel(string id)
        {
            var existingChannel = await _channelService.GetChannelByIdAsync(id);
            if (existingChannel == null)
            {
                return NotFound();
            }
            await _channelService.DeleteChannelAsync(id);
            return NoContent();
        }
    }
}


