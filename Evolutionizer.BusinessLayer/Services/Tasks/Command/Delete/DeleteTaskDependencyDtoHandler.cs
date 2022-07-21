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
    public class DeleteTaskDependencyDtoHandler : IRequestHandler<DeleteTaskDependencyDto, bool>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public DeleteTaskDependencyDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteTaskDependencyDto request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetTaskById(request.Id);
            if (entity == null) throw new EntityNotFoundException(nameof(Entities.Task), request.Id);
            if(entity.ChildTaskDependency.Count == 0) throw new EntityNotFoundException(nameof(Entities.Task.ChildTaskDependency), request.Id);
            entity.ChildTaskDependency.Clear();
            await _repository.UpdateTask(entity);
            return true;
        }
    }
}
