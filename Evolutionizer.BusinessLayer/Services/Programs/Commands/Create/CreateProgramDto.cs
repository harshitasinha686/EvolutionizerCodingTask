using Evolutionizer.BusinessLayer.Services.CommonDto;
using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Programs.Commands.Create
{
    public class CreateProgramDto : IRequest<ProgramViewModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }
}
