using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using OpenAiVideoSummary.Api.Model;
using OpenAiVideoSummary.Api.Repository;
using OpenAiVideoSummary.Api.Service;
using Xunit;

namespace OpenAiVideoSummary.Api.Tests
{
    public class VideoServiceTests
    {
        private readonly Mock<IBaseRepository<Video>> _mockVideoRepository;
        private readonly VideoService _videoService;

        public VideoServiceTests()
        {
            _mockVideoRepository = new Mock<IBaseRepository<Video>>();
            _videoService = new VideoService(_mockVideoRepository.Object);
        }

        [Fact]
        public async Task GetAllVideosAsync_ReturnsAllVideos()
        {
            // Arrange
            var videos = new List<Video>
            {
                new Video { VideoId = "1", Title = "Video 1" },
                new Video { VideoId = "2", Title = "Video 2" }
            };
            _mockVideoRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(videos);

            // Act
            var result = await _videoService.GetAllVideosAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Video 1", result[0].Title);
            Assert.Equal("Video 2", result[1].Title);
        }

        [Fact]
        public async Task GetVideoByIdAsync_ReturnsVideo()
        {
            // Arrange
            var video = new Video { VideoId = "1", Title = "Video 1" };
            _mockVideoRepository.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(video);

            // Act
            var result = await _videoService.GetVideoByIdAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Video 1", result.Title);
        }

        [Fact]
        public async Task CreateVideoAsync_CreatesVideo()
        {
            // Arrange
            var video = new Video { VideoId = "1", Title = "Video 1" };

            // Act
            await _videoService.CreateVideoAsync(video);

            // Assert
            _mockVideoRepository.Verify(repo => repo.CreateAsync(video), Times.Once);
        }

        [Fact]
        public async Task UpdateVideoAsync_UpdatesVideo()
        {
            // Arrange
            var video = new Video { VideoId = "1", Title = "Updated Video" };

            // Act
            await _videoService.UpdateVideoAsync("1", video);

            // Assert
            _mockVideoRepository.Verify(repo => repo.UpdateAsync("1", video), Times.Once);
        }

        [Fact]
        public async Task DeleteVideoAsync_DeletesVideo()
        {
            // Arrange

            // Act
            await _videoService.DeleteVideoAsync("1");

            // Assert
            _mockVideoRepository.Verify(repo => repo.DeleteAsync("1"), Times.Once);
        }
    }
}


