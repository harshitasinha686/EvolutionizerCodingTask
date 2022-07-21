using AutoMapper;
using Evolutionizer.BusinessLayer.ExceptionHandling;
using Evolutionizer.BusinessLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Tasks.Command.Delete
{
    public class DeleteTaskDtoHandler : IRequestHandler<DeleteTaskDto, bool>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public DeleteTaskDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteTaskDto request, CancellationToken cancellationToken)
        {
            var taskEntity = await _repository.GetTaskById(request.Id);
            if (taskEntity == null) throw new EntityNotFoundException(nameof(BusinessLayer.Entities.Task), request.Id);
            await _repository.DeleteTask(taskEntity);
            
            return true;
        }
    }
}
