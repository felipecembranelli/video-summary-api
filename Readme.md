﻿# OpenAI Video Summary API

This project is an API for managing video summaries using MongoDB as the database. It includes models, repositories, services, and controllers for `Channel` and `Video` entities.

## Project Structure


## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MongoDB](https://www.mongodb.com/try/download/community)

### Setup

1. Clone the repository:

git clone https://github.com/yourusername/OpenAiVideoSummary.Api.git cd OpenAiVideoSummary.Api


2. Install dependencies:

dotnet restore

3. Add the MongoDB.Driver package:

dotnet add package MongoDB.Driver

4. Add the xUnit and Moq packages for testing:

dotnet add package xunit dotnet add package xunit.runner.visualstudio dotnet add package Moq

### Configuration

Configure your MongoDB connection string in `appsettings.json`:

{ "ConnectionStrings": { "MongoDb": "mongodb://localhost:27017/yourdatabase" } }


### Running the Application

Run the application using the following command:

dotnet run

### Running the Tests

Run the tests using the following command:

dotnet test

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

## Built With

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [xUnit](https://xunit.net/)
- [Moq]



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







