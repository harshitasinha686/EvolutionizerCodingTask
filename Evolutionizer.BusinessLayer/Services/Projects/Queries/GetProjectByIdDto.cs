using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Projects.Queries
{
    public class GetProjectByIdDto : IRequest<ProjectViewModel>
    {
        public int Id { get; set; }
    }
}
