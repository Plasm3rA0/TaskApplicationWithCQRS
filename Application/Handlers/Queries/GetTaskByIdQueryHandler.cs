using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskApplicationWithCQRS.Domain;
using TaskApplicationWithCQRS.Infrastructure.Data;
using TaskApplicationWithCQRS.Infrastructure.Exceptions;
using TaskApplicationWithCQRS.Infrastructure.Queries;

namespace TaskApplicationWithCQRS.Application.Handlers.Queries
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDto>
    {


        private readonly ApplicationDbContext _context;


        public GetTaskByIdQueryHandler(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<TaskItemDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            TaskItem? taskItem = await _context.TaskItems.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(taskItem == null) throw new TaskItemNotFoundException($"Task item with id {request.Id} not found.");

            return new TaskItemDto(taskItem);
        }
    }
}
