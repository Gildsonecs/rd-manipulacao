using Newtonsoft.Json;
using RdManipulation.Application.Models;
using RdManipulation.Domain.Entities;

namespace RdManipulation.Infra.Service
{
    public class YouTubeApiService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _apiKey = Environment.GetEnvironmentVariable("YOUTUBE_API_KEY")
                ?? throw new ArgumentNullException("API Key não encontrada.");

        public async Task<List<Video>> SearchVideosAsync(string query) 
        {
            var url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&q={query}&key={_apiKey}&publishedAfter=2025-01-01T00:00:00Z&regionCode=BR";

            var response = await _httpClient.GetStringAsync(url);

            var searchResponse = JsonConvert.DeserializeObject<YouTubeVideoSearchResponse>(response);

            var videos = new List<Video>();
            foreach (var item in searchResponse.Items)
            {
                var videoId = item.Id.VideoId;
                var videoDetails = await GetVideoDetailsAsync(videoId);

                var video = new Video
                {
                    Title = item.Snippet.Title,
                    Description = item.Snippet.Description,
                    Channel = item.Snippet.ChannelTitle,
                    PublishedAt = item.Snippet.PublishedAt,
                    Duration = videoDetails.Duration
                };
                videos.Add(video);
            }

            return videos;
        }

        private async Task<VideoDetails> GetVideoDetailsAsync(string videoId)
        {
            var detailsUrl = $"https://www.googleapis.com/youtube/v3/videos?part=contentDetails&id={videoId}&key={_apiKey}";

            var detailsResponse = await _httpClient.GetStringAsync(detailsUrl);

            var detailsResult = JsonConvert.DeserializeObject<YouTubeVideoDetailsResponse>(detailsResponse);

            // Extrair a duração do primeiro item (único vídeo)
            var duration = detailsResult.Items.FirstOrDefault()?.ContentDetails.Duration ?? "PT0S";
            return new VideoDetails { Duration = duration };
        }

    }
}
