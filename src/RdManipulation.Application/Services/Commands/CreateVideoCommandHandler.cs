using MediatR;
using RdManipulation.Domain.Entities;
using RdManipulation.Infra.Data.Contexts;

namespace RdManipulation.Application.Services.Commands
{
    public class CreateVideoCommandHandler(AppDbContext dbContext) : IRequestHandler<CreateVideoCommand, Unit>
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            var video = new Video
            {
                Title = request.Title,
                Description = request.Description,
                Channel = request.Channel,
                Duration = request.Duration,
                PublishedAt = request.PublishedAt,
                IsDeleted = false
            };

            _dbContext.Videos.Add(video);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
