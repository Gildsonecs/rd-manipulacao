using MediatR;
using Microsoft.EntityFrameworkCore;
using RdManipulation.Domain.Dtos;
using RdManipulation.Infra.Data.Contexts;

namespace RdManipulation.Application.Services.Queries
{
    public class GetVideosQueryHandler(AppDbContext dbContext) : IRequestHandler<GetVideosQuery, List<VideoDto>>
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<List<VideoDto>> Handle(GetVideosQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Videos.AsQueryable();

            if (!string.IsNullOrEmpty(request.Titulo))
                query = query.Where(v => v.Title.Contains(request.Titulo));

            if (!string.IsNullOrEmpty(request.Duracao))
                query = query.Where(v => v.Duration.Contains(request.Duracao));

            if (!string.IsNullOrEmpty(request.Autor))
                query = query.Where(v => v.Channel.Contains(request.Autor));

            if (!string.IsNullOrEmpty(request.Q))
                query = query.Where(v => v.Title.Contains(request.Q) || v.Description.Contains(request.Q) || v.Channel.Contains(request.Q));

            return await query.Select(v => new VideoDto
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                Channel = v.Channel,
                Duration = v.Duration,
                PublishedAt = v.PublishedAt,
                IsDeleted = v.IsDeleted
            }).ToListAsync(cancellationToken);
        }
    }

}
