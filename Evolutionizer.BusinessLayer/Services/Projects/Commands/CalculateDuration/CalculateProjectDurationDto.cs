using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Projects.Commands.CalculateDuration
{
    public class CalculateProjectDurationDto :IRequest<ProjectViewModel>
    {
        public int Id { get; set; }
    }
}
