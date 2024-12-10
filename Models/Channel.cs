using System;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenAiVideoSummary.Api.Model
{
    [BsonIgnoreExtraElements]
    public class Channel
    {
        [BsonElement("channelId")]
        public string ChannelId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("thumbnailMediumUrl")]
        public string ThumbnailMediumUrl { get; set; }

        [BsonElement("thumbnailMediumHeight")]
        public string ThumbnailMediumHeight { get; set; }

        [BsonElement("thumbnailMediumWidth")]
        public string ThumbnailMediumWidth { get; set; }

        [BsonElement("chanhelCategory")]
        public string ChanhelCategory { get; set; } = "";

        [BsonElement("channelDescription")]
        public string ChannelDescription { get; set; } = "";

        [BsonElement("lastUpdated")]
        public string LastUpdated { get; set; } = "";

        [BsonElement("channelUpdateFlag")]
        public bool ChannelUpdateFlag { get; set; } = false;
    }
}
