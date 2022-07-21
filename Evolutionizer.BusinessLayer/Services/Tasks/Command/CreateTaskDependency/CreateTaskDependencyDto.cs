using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Tasks.Command.CreateTaskDependency
{
    public class CreateTaskDependencyDto : IRequest<bool>
    {
        public int Id { get; set; }
        public List<int> DependentIds { get; set; }
    }
}
