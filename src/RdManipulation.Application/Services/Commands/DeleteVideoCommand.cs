using MediatR;

namespace RdManipulation.Application.Services.Commands
{
    public class DeleteVideoCommand(int id) : IRequest<bool>
    {
        public int Id { get; set; } = id;
    }
}
