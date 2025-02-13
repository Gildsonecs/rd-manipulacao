using MediatR;

namespace RdManipulation.Application.Services.Commands
{
    public class CreateVideoCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Channel { get; set; }
        public string Duration { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
