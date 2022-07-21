using AutoMapper;
using Evolutionizer.BusinessLayer.Entities;
using Evolutionizer.BusinessLayer.ExceptionHandling;
using Evolutionizer.BusinessLayer.Interfaces;
using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Projects.Commands.CalculateDuration
{
    public class CalculateProjectDurationDtoHandler : IRequestHandler<CalculateProjectDurationDto, ProjectViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CalculateProjectDurationDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProjectViewModel> Handle(CalculateProjectDurationDto request, CancellationToken cancellationToken)
        {
            var entityProject = await _repository.GetProjectById(request.Id, true);
            if (entityProject == null) throw new EntityNotFoundException(nameof(Project), request.Id);
            //var durationWithNoTaskDependency = new List<double>();
            
            //var duration = 0.0;
            var entityTask = entityProject.GetTaskWithMaxChildTaskDuration();
           
                //foreach (var item in entityProject.Tasks)
                //{
                //    if (item.ChildTaskDependency.Count == 0)
                //    {
                //        durationWithNoTaskDependency.Add(item.Duration);
                //    }
                //}
                //var projectDurationWithTasksWithNoTaskDependency = durationWithNoTaskDependency.Max();
            
            
                var duration = entityTask.GetLongestTaskDependencyDuration();
            
            entityProject.Duration = duration;
            await _repository.UpdateProject(entityProject);
            var result = _mapper.Map<ProjectViewModel>(entityProject);

            return result;
        }
    }
}
