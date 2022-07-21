using Evolutionizer.BusinessLayer.Services.Projects.Commands;
using Evolutionizer.BusinessLayer.Services.Projects.Commands.CalculateDuration;
using Evolutionizer.BusinessLayer.Services.Projects.Commands.Delete;
using Evolutionizer.BusinessLayer.Services.Projects.Commands.Edit;
using Evolutionizer.BusinessLayer.Services.Projects.Queries;
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
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("createproject")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto createProjectDto)
        {
            var res = await _mediator.Send(createProjectDto);
            return Ok(res);
        }

        [HttpGet]
        [Route("getprojectbyid")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var res = await _mediator.Send(new GetProjectByIdDto { Id = id});
            return Ok(res);
        }

        [HttpDelete]
        [Route("deleteproject")]
        public async Task<IActionResult> DeleteProject([FromQuery] int id)
        {
            var res = await _mediator.Send(new DeleteProjectDto(id));
            return Ok(res);
        }

        [HttpPut]
        [Route("updateproject")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectDto updateProjectDto)
        {
            var res = await _mediator.Send(updateProjectDto);
            return Ok(res);
        }

        [HttpPut]
        [Route("calculateduration")]
        public async Task<IActionResult> CalculateDuration([FromBody] CalculateProjectDurationDto projectDuration)
        {
            var res = await _mediator.Send(projectDuration);
            return Ok(res);
        }
    }
}
