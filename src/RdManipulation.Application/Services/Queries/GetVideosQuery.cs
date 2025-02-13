using MediatR;
using RdManipulation.Domain.Dtos;

namespace RdManipulation.Application.Services.Queries
{
    public class GetVideosQuery : IRequest<List<VideoDto>>
    {
        public string? Titulo { get; set; }
        public string? Duracao { get; set; } 
        public string? Autor { get; set; } 
        public string? Q { get; set; } 
    }
}
