using MediatR;
using TaskApplicationWithCQRS.Domain;

namespace TaskApplicationWithCQRS.Infrastructure.Commands
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}
