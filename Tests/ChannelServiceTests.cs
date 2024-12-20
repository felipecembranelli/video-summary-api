using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using OpenAiVideoSummary.Api.Model;
using OpenAiVideoSummary.Api.Repository;
using OpenAiVideoSummary.Api.Service;
using Xunit;

namespace OpenAiVideoSummary.Api.Tests
{
    public class ChannelServiceTests
    {
        private readonly Mock<IBaseRepository<Channel>> _mockChannelRepository;
        private readonly Mock<IVideoRepository<Video>> _mockVideoRepository;
        private readonly ChannelService _channelService;

        public ChannelServiceTests()
        {
            _mockChannelRepository = new Mock<IBaseRepository<Channel>>();
            _mockVideoRepository = new Mock<IVideoRepository<Video>>();
            _channelService = new ChannelService(_mockChannelRepository.Object, _mockVideoRepository.Object);
        }

        [Fact]
        public async Task GetAllChannelsAsync_ReturnsAllChannels()
        {
            // Arrange
            var channels = new List<Channel>
            {
                new Channel { ChannelId = "1", Title = "Channel 1" },
                new Channel { ChannelId = "2", Title = "Channel 2" }
            };
            _mockChannelRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(channels);

            // Act
            var result = await _channelService.GetAllChannelsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Channel 1", result[0].Title);
            Assert.Equal("Channel 2", result[1].Title);
        }

        [Fact]
        public async Task GetChannelByIdAsync_ReturnsChannel()
        {
            // Arrange
            var channel = new Channel { ChannelId = "1", Title = "Channel 1" };
            _mockChannelRepository.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(channel);

            // Act
            var result = await _channelService.GetChannelByIdAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Channel 1", result.Title);
        }

        [Fact]
        public async Task CreateChannelAsync_CreatesChannel()
        {
            // Arrange
            var channel = new Channel { ChannelId = "1", Title = "Channel 1" };

            // Act
            await _channelService.CreateChannelAsync(channel);

            // Assert
            _mockChannelRepository.Verify(repo => repo.CreateAsync(channel), Times.Once);
        }

        [Fact]
        public async Task UpdateChannelAsync_UpdatesChannel()
        {
            // Arrange
            var channel = new Channel { ChannelId = "1", Title = "Updated Channel" };

            // Act
            await _channelService.UpdateChannelAsync("1", channel);

            // Assert
            _mockChannelRepository.Verify(repo => repo.UpdateAsync("1", channel), Times.Once);
        }

        [Fact]
        public async Task DeleteChannelAsync_DeletesChannel()
        {
            // Arrange

            // Act
            await _channelService.DeleteChannelAsync("1");

            // Assert
            _mockChannelRepository.Verify(repo => repo.DeleteAsync("1"), Times.Once);
        }
    }
}


