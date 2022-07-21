using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Projects.Commands.Edit
{
    public class UpdateProjectDto : IRequest<ProjectViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
