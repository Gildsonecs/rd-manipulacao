using MediatR;
using RdManipulation.Domain.Interfaces;

namespace RdManipulation.Application.Services.Commands
{
    public class UpdateVideoCommandHandler(IVideoRepository videoRepository) : IRequestHandler<UpdateVideoCommand, bool>
    {
        private readonly IVideoRepository _videoRepository = videoRepository;

        public async Task<bool> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetByIdAsync(request.Id);
            if (video == null) return false;

            video.Title = request.Title;
            video.Description = request.Description;
            video.Channel = request.Channel; 
            video.Duration = request.Duration;
            video.PublishedAt = request.PublishedAt;

            return await _videoRepository.UpdateAsync(video);
        }
    }
}
