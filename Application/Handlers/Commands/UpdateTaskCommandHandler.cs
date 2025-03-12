using MediatR;
using TaskApplicationWithCQRS.Domain;
using TaskApplicationWithCQRS.Infrastructure.Commands;
using TaskApplicationWithCQRS.Infrastructure.Data;
using TaskApplicationWithCQRS.Infrastructure.Exceptions;

namespace TaskApplicationWithCQRS.Application.Handlers.Commands
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskItemDto>
    {


        private readonly ApplicationDbContext _context;


        public UpdateTaskCommandHandler(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<TaskItemDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            TaskItem? taskItem = _context.TaskItems.FirstOrDefault(x => x.Id == request.Id);

            if (taskItem == null) throw new TaskItemNotFoundException($"Task item with id {request.Id} not found.");

            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsCompleted = request.IsDone;

            await _context.SaveChangesAsync();

            return new TaskItemDto(taskItem);
        }
    }
}
