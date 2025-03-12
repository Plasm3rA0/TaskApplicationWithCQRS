using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskApplicationWithCQRS.Domain;
using TaskApplicationWithCQRS.Infrastructure.Commands;
using TaskApplicationWithCQRS.Infrastructure.Data;
using TaskApplicationWithCQRS.Infrastructure.Exceptions;

namespace TaskApplicationWithCQRS.Application.Handlers.Commands
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteTaskCommandHandler(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            TaskItem? taskItem = await _context.TaskItems.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(taskItem == null) throw new TaskItemNotFoundException($"Task item with id {request.Id} not found.");

            _context.TaskItems.Remove(taskItem);

            return true;
        }
    }
}
