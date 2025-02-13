using MediatR;

namespace RdManipulation.Application.Services.Commands
{
    public class UpdateVideoCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Channel { get; set; } 
        public string? Duration { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
