namespace RdManipulation.Application.Models
{

    public class YouTubeVideoSearchResponse
    {
        public List<YouTubeSearchItem> Items { get; set; }
    }

    public class YouTubeSearchItem
    {
        public YouTubeId Id { get; set; }
        public YouTubeSnippet Snippet { get; set; }
    }

    public class YouTubeId
    {
        public string VideoId { get; set; }
    }

    public class YouTubeSnippet
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ChannelTitle { get; set; }
        public DateTime PublishedAt { get; set; }
    }

    public class YouTubeVideoDetailsResponse
    {
        public List<YouTubeVideoDetailsItem> Items { get; set; }
    }

    public class YouTubeVideoDetailsItem
    {
        public YouTubeContentDetails ContentDetails { get; set; }
    }

    public class YouTubeContentDetails
    {
        public string Duration { get; set; }
    }

    public class VideoDetails
    {
        public string Duration { get; set; }
    }
}
