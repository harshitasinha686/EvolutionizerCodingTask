using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Tasks.Command.Delete
{
    public class DeleteTaskDependencyDto : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteTaskDependencyDto(int id)
        {
            Id = id;
        }
    }
}
