using AutoMapper;
using Evolutionizer.BusinessLayer.Entities;
using Evolutionizer.BusinessLayer.ExceptionHandling;
using Evolutionizer.BusinessLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Tasks.Command.CreateTaskDependency
{
    public class CreateTaskDependencyDtoHandler : IRequestHandler<CreateTaskDependencyDto, bool>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CreateTaskDependencyDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateTaskDependencyDto request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetTaskById(request.Id);
            if (entity == null) throw new EntityNotFoundException(nameof(Entities.Task), request.Id);

            var childTasks = await _repository.GetTasksByIds(request.DependentIds);
            if (childTasks.Count == 0) throw new EntityNotFoundException(nameof(Entities.Task),request.DependentIds);

            if (childTasks.Count > 0)
            {
                var dependency = new List<TaskDependency>();
                foreach (var item in childTasks)
                {
                    var childDependency = new TaskDependency() { ParentTaskId = request.Id, ChildTaskId = item.Id };
                    dependency.Add(childDependency);
                }
                entity.UpdateTaskDependency(dependency);
                await _repository.UpdateTask(entity);
            }
            return true;
        }
    }
}
