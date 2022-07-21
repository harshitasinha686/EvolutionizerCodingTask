using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;

namespace Evolutionizer.BusinessLayer.Services.Programs.Commands.CalculateDuration
{
    public class CalculateProgramDurationDto : IRequest<ProgramViewModel>
    {
        public int Id { get; set; }
    }
}
