using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenAiVideoSummary.Api.Model;
using OpenAiVideoSummary.Api.Service;

namespace OpenAiVideoSummary.Api.Controllers
{
    /// <summary>
    /// Controller for managing video resources.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoController"/> class.
        /// </summary>
        /// <param name="videoService">The video service.</param>
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        /// <summary>
        /// Gets all videos.
        /// </summary>
        /// <returns>A list of videos.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Video>>> GetAllVideos()
        {
            var videos = await _videoService.GetAllVideosAsync();
            return Ok(videos);
        }

        /// <summary>
        /// Gets a video by its ID.
        /// </summary>
        /// <param name="id">The ID of the video.</param>
        /// <returns>The video with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideoById(string id)
        {
            var video = await _videoService.GetVideoByIdAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        /// <summary>
        /// Creates a new video.
        /// </summary>
        /// <param name="video">The video to create.</param>
        /// <returns>The created video.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateVideo([FromBody] Video video)
        {
            await _videoService.CreateVideoAsync(video);
            return CreatedAtAction(nameof(GetVideoById), new { id = video.VideoId }, video);
        }

        /// <summary>
        /// Updates a video.
        /// </summary>
        /// <param name="id">The ID of the video to update.</param>
        /// <param name="video">The updated video.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVideo(string id, [FromBody] Video video)
        {
            var existingVideo = await _videoService.GetVideoByIdAsync(id);
            if (existingVideo == null)
            {
                return NotFound();
            }
            await _videoService.UpdateVideoAsync(id, video);
            return NoContent();
        }

        /// <summary>
        /// Deletes a video.
        /// </summary>
        /// <param name="id">The ID of the video to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVideo(string id)
        {
            var existingVideo = await _videoService.GetVideoByIdAsync(id);
            if (existingVideo == null)
            {
                return NotFound();
            }
            await _videoService.DeleteVideoAsync(id);
            return NoContent();
        }
    }
}
