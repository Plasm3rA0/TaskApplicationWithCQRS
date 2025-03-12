using MediatR;
using TaskApplicationWithCQRS.Domain;

namespace TaskApplicationWithCQRS.Infrastructure.Commands
{
    public record CreateTaskCommand(string Title, string Description) : IRequest<TaskItemDto>;
}
