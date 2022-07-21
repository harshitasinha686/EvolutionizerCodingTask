using Evolutionizer.BusinessLayer.Services.CommonDto;
using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Projects.Commands
{
    public class CreateProjectDto : IRequest<ProjectViewModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProgramId { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}
