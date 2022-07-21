using Evolutionizer.BusinessLayer.Services.Tasks.Command;
using Evolutionizer.BusinessLayer.Services.Tasks.Command.CalculateDuration;
using Evolutionizer.BusinessLayer.Services.Tasks.Command.CreateTaskDependency;
using Evolutionizer.BusinessLayer.Services.Tasks.Command.Delete;
using Evolutionizer.BusinessLayer.Services.Tasks.Command.Edit;
using Evolutionizer.BusinessLayer.Services.Tasks.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolutionizerCodingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("createtask")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            var res = await _mediator.Send(createTaskDto);
            return Ok(res);
        }

        [HttpGet]
        [Route("gettaskbyid")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var res = await _mediator.Send(new GetTaskByIdDto(id));
            return Ok(res);
        }

        [HttpDelete]
        [Route("deletetask")]
        public async Task<IActionResult> DeleteTask([FromQuery] int id)
        {
            var res = await _mediator.Send(new DeleteTaskDto(id));
            return Ok(res);
        }

        [HttpPut]
        [Route("updatetask")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskDto updateTaskDto)
        {
            var res = await _mediator.Send(updateTaskDto);
            return Ok(res);
        }

        [HttpPut]
        [Route("updatetaskdates")]
        public async Task<IActionResult> UpdateTaskStartAndEndDates([FromBody] UpdateStartEndDateDto updateTaskDto)
        {
            var res = await _mediator.Send(updateTaskDto);
            return Ok(res);
        }

        [HttpPost]
        [Route("createtaskdependency")]
        public async Task<IActionResult> CreateTaskDependency([FromBody] CreateTaskDependencyDto createTaskDependencyDto)
        {
            var res = await _mediator.Send(createTaskDependencyDto);
            return Ok(res);
        }

        [HttpDelete]
        [Route("deletetaskdependency")]
        public async Task<IActionResult> DeleteTaskDependency([FromQuery] int id)
        {
            var res = await _mediator.Send(new DeleteTaskDependencyDto(id));
            return Ok(res);
        }

        [HttpPut]
        [Route("calculateduration")]
        public async Task<IActionResult> CalculateDuration([FromBody] CalculateTaskDurationDto taskDuration)
        {
            var res = await _mediator.Send(taskDuration);
            return Ok(res);
        }
    }
}
