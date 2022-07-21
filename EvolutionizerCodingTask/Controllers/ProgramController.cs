using Evolutionizer.BusinessLayer.Services.Programs.Commands.CalculateDuration;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.Create;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.Delete;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.Edit;
using Evolutionizer.BusinessLayer.Services.Programs.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EvolutionizerCodingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("createprogram")]
        public async Task<IActionResult> CreateProgram([FromBody] CreateProgramDto createProgramDto)
        {
            var res = await _mediator.Send(createProgramDto);
            return Ok(res);
        }

        [HttpGet]
        [Route("getprogrambyid")]
        public async Task<IActionResult> GetProgramById([FromQuery]int id)
        {
            var res = await _mediator.Send(new GetProgramByIdDto { Id = id }) ;
            return Ok(res);
        }

        [HttpDelete]
        [Route("deleteprogram")]
        public async Task<IActionResult> DeleteProgram([FromQuery] int id)
        {
            var res = await _mediator.Send(new DeleteProgramDto(id));
            return Ok(res);
        }

        [HttpGet]
        [Route("getallprogram")]
        public async Task<IActionResult> GetAllProgram()
        {
            var res = await _mediator.Send(new GetAllProgramDto());
            return Ok(res);
        }

        [HttpPut]
        [Route("updateprogram")]
        public async Task<IActionResult> UpdateProgram([FromBody] UpdateProgramDto updateProgramDto)
        {
            var res = await _mediator.Send(updateProgramDto);
            return Ok(res);
        }

        [HttpPut]
        [Route("calculateduration")]
        public async Task<IActionResult> CalculateDuration([FromBody] CalculateProgramDurationDto programDuration)
        {
            var res = await _mediator.Send(programDuration);
            return Ok(res);
        }
    }
}
