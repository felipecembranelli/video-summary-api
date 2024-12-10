using System;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenAiVideoSummary.Api.Model
{
    [BsonIgnoreExtraElements]
    public class Video
    {
        [BsonElement("videoId")]
        public string VideoId { get; set; } = "";

        [BsonElement("channelId")]
        public string ChannelId { get; set; }

        [BsonElement("videoName")]
        public string VideoName { get; set; } = "";

        [BsonElement("title")]
        public string Title { get; set; } = "";

        [BsonElement("description")]
        public string Description { get; set; } = "";

        [BsonElement("videoUrl")]
        public string VideoUrl { get; set; } = "";

        [BsonElement("summary")]
        public string Summary { get; set; } = "";
    }
}
