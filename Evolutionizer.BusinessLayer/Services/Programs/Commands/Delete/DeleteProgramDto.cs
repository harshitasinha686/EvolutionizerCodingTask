using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Programs.Commands.Delete
{
    public class DeleteProgramDto : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteProgramDto(int id)
        {
            Id = id;
        }
    }
    
}
