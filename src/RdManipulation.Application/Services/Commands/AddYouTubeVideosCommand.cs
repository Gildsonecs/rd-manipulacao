using MediatR;

namespace RdManipulation.Application.Services.Commands
{
    public class AddYouTubeVideosCommand : IRequest<Unit> 
    {
        public string Query { get; set; }
    }
}
