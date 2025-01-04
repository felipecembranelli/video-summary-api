# YoutubeBlink API (OpenAI Video Summary API)

This API is part of the YouTubeBlink application, an app used to automatically create video summaries of YouTube channels and help me keep track of my favorite content. The full description of the solution can be found in the article below. Initially I used Langchain, Javascript and OpenAI APIs. Later I rewrote the API in .NET, for study and learning purposes.

Live App Demo: https://openai-video-summary-fe.vercel.app/

Medium article: https://medium.com/@felipecembranelli/youtubeblink-an-openai-video-summary-generator-37ab541c9493

![Screen Shot 2024-06-04 at 10 40 50 AM](https://github.com/felipecembranelli/youtubeblink/assets/5788479/9d1e8c24-7536-490c-b22c-c7a4ad8c2745)

## Getting Started

### Prerequisites to access API specification (swagger)

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Setup

1. Clone the repository:

```
git clone https://github.com/felipecembranelli/video-summary-api.git

```
2. Install dependencies:

```
dotnet restore

```

### Running the Application

Run the application using the following command:

```
dotnet run

```

### Running the Tests

Run the tests using the following command:

```
dotnet test
```

## API Endpoints

The API exposes the following endpoints:

- `GET /api/channels`: Get all channels
- `GET /api/channels/{id}`: Get a channel by ID
- `POST /api/channels`: Create a new channel
- `PUT /api/channels/{id}`: Update a channel by ID
- `DELETE /api/channels/{id}`: Delete a channel by ID
- `GET /api/channels/{channelId}/videos`: Get all videos for a channel
- `GET /api/channels/{channelId}/videos/{videoId}`: Get a video by ID for a channel
- `POST /api/channels/{channelId}/videos`: Create a new video for a channel
- `PUT /api/channels/{channelId}/videos/{videoId}`: Update a video by ID for a channel
- `DELETE /api/channels/{channelId}/videos/{videoId}`: Delete a video by ID for a channel
- `GET /api/videos`: Get all videos
- `GET /api/videos/{id}`: Get a video by ID
- `POST /api/videos`: Create a new video
- `PUT /api/videos/{id}`: Update a video by ID
- `DELETE /api/videos/{id}`: Delete a video by ID
- `GET /api/videos/{videoId}/summary`: Get the summary for a video
- `POST /api/videos/{videoId}/summary`: Generate a summary for a video


### Configuration (run full API)

Configure your MongoDB connection string in `appsettings.json`:

- [MongoDB](https://www.mongodb.com/try/download/community)

```
{ "ConnectionStrings": { "MongoDb": "mongodb://localhost:27017/yourdatabase" } }
```

## Code Structure

### Models

- `Channel.cs`: Represents a channel entity.
- `Video.cs`: Represents a video entity.

### Repositories

- `BaseRepository.cs`: Provides basic CRUD operations for MongoDB collections.
- `ChannelRepository.cs`: Inherits from `BaseRepository` and provides additional methods specific to the `Channel` entity.
- `VideoRepository.cs`: Inherits from `BaseRepository` and provides additional methods specific to the `Video` entity.

### Services

- `ChannelService.cs`: Provides business logic for `Channel` entities.
- `VideoService.cs`: Provides business logic for `Video` entities.

### Controllers

- `ChannelController.cs`: Handles HTTP requests for `Channel` entities.
- `VideoController.cs`: Handles HTTP requests for `Video` entities.

### Tests

- `ChannelServiceTests.cs`: Unit tests for `ChannelService`.
- `VideoServiceTests.cs`: Unit tests for `VideoService`.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes.

- ## Authors
- Felipe Cembranelli

- ## License
- This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.







