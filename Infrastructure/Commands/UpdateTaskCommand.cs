using MediatR;
using TaskApplicationWithCQRS.Domain;

namespace TaskApplicationWithCQRS.Infrastructure.Commands
{
    public record UpdateTaskCommand(int Id, string Title, string Description, bool IsDone) : IRequest<TaskItemDto>;
}
