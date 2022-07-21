using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Projects.Commands.Delete
{
    public class DeleteProjectDto : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteProjectDto(int id)
        {
            Id = id;
        }
    }
}
