using System.Collections.Generic;
using System.Threading.Tasks;
using OpenAiVideoSummary.Api.Model;
using OpenAiVideoSummary.Api.Repository;

namespace OpenAiVideoSummary.Api.Service
{
    /// <summary>
    /// Represents a service for managing videos.
    /// </summary>
    public class VideoService : IVideoService
    {
        private readonly IBaseRepository<Video> _videoRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoService"/> class.
        /// </summary>
        /// <param name="videoRepository">The video repository.</param>
        public VideoService(IBaseRepository<Video> videoRepository)
        {
            _videoRepository = videoRepository;
        }

        /// <summary>
        /// Gets all videos asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of videos.</returns>
        public async Task<List<Video>> GetAllVideosAsync()
        {
            return await _videoRepository.GetAllAsync();
        }

        /// <summary>
        /// Gets a video by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the video.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the video with the specified ID.</returns>
        public async Task<Video> GetVideoByIdAsync(string id)
        {
            return await _videoRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Creates a new video asynchronously.
        /// </summary>
        /// <param name="video">The video to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateVideoAsync(Video video)
        {
            await _videoRepository.CreateAsync(video);
        }

        /// <summary>
        /// Updates a video asynchronously.
        /// </summary>
        /// <param name="id">The ID of the video to update.</param>
        /// <param name="video">The updated video.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateVideoAsync(string id, Video video)
        {
            await _videoRepository.UpdateAsync(id, video);
        }

        /// <summary>
        /// Deletes a video asynchronously.
        /// </summary>
        /// <param name="id">The ID of the video to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteVideoAsync(string id)
        {
            await _videoRepository.DeleteAsync(id);
        }

        // You can add additional methods specific to the Video service here
    }
}

