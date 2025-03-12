using MediatR;
using TaskApplicationWithCQRS.Domain;

namespace TaskApplicationWithCQRS.Infrastructure.Queries
{
    public record GetAllTasksQuery : IRequest<IEnumerable<TaskItemDto>>;
}
