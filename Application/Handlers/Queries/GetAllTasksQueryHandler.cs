using MediatR;
using TaskApplicationWithCQRS.Domain;
using TaskApplicationWithCQRS.Infrastructure.Data;
using TaskApplicationWithCQRS.Infrastructure.Queries;

namespace TaskApplicationWithCQRS.Application.Handlers.Queries
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItemDto>>
    {


        private readonly ApplicationDbContext _context;


        public GetAllTasksQueryHandler(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return _context.TaskItems.Select(x => new TaskItemDto(x));
        }
    }
}
