using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApplicationWithCQRS.Domain;
using TaskApplicationWithCQRS.Infrastructure.Commands;
using TaskApplicationWithCQRS.Infrastructure.Queries;

namespace TaskApplicationWithCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {


        private readonly IMediator bus;


        public TaskController(IMediator mediator)
        {
            bus = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<TaskItemDto>> GetAll()
        {
            return await bus.Send(new GetAllTasksQuery());
        }


        [HttpGet("{id}")]
        public async Task<TaskItemDto> GetById(int id)
        {
            return await bus.Send(new GetTaskByIdQuery(id));
        }

        [HttpPost]
        public async Task<TaskItemDto> Create([FromBody] CreateTaskCommand command)
        {
            return await bus.Send(command);
        }

        [HttpPut]
        public async Task<TaskItemDto> Update([FromBody] UpdateTaskCommand command)
        {
            return await bus.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await bus.Send(new DeleteTaskCommand(id));
            return Ok();
        }
    }
}
