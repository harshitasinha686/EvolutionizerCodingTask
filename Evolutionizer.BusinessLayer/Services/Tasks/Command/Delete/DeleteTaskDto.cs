using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Tasks.Command.Delete
{
    public class DeleteTaskDto : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteTaskDto(int id)
        {
            Id = id;
        }
    }
}
