using MediatR;
using TaskApplicationWithCQRS.Domain;

namespace TaskApplicationWithCQRS.Infrastructure.Queries
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskItemDto>;
}
