using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;

namespace Evolutionizer.BusinessLayer.Services.Tasks.Command.CalculateDuration
{
    public class CalculateTaskDurationDto : IRequest<TaskViewModel>
    {
        public int Id { get; set; }
    }
}
