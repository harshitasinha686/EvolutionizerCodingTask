using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Tasks.Queries
{
    public class GetTaskByIdDto : IRequest<TaskViewModel>
    {
        public int Id { get; set; }
        public GetTaskByIdDto(int id)
        {
            Id = id;
        }
    }
}
