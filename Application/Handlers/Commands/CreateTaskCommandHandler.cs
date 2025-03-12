using MediatR;
using TaskApplicationWithCQRS.Domain;
using TaskApplicationWithCQRS.Infrastructure.Commands;
using TaskApplicationWithCQRS.Infrastructure.Data;

namespace TaskApplicationWithCQRS.Application.Handlers.Commands
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {


        private readonly ApplicationDbContext _context;


        public CreateTaskCommandHandler(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description
            };

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };
        }
    }
}
