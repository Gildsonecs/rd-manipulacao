using MediatR;
using RdManipulation.Infra.Data.Contexts;
using RdManipulation.Infra.Service;

namespace RdManipulation.Application.Services.Commands
{
    public class SearchVideosQueryHandler(YouTubeApiService youTubeApiService, AppDbContext dbContext) : IRequestHandler<AddYouTubeVideosCommand, Unit>
    {
        private readonly YouTubeApiService _youTubeApiService = youTubeApiService;
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(AddYouTubeVideosCommand request, CancellationToken cancellationToken)
        {
            var videos = await _youTubeApiService.SearchVideosAsync(request.Query);

            if (videos.Any())
            {
                foreach (var video in videos)
                {
                    _dbContext.Videos.Add(video);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
            }
            return Unit.Value;
        }
    }
}
