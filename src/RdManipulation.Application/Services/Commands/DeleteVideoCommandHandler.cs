using MediatR;
using RdManipulation.Domain.Interfaces;

namespace RdManipulation.Application.Services.Commands
{
    public class DeleteVideoCommandHandler(IVideoRepository videoRepository) : IRequestHandler<DeleteVideoCommand, bool>
    {
        private readonly IVideoRepository _videoRepository = videoRepository;

        public async Task<bool> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetByIdAsync(request.Id);
            if (video == null) return false;

            video.IsDeleted = true;
            return await _videoRepository.UpdateAsync(video);
        }
    }
}
