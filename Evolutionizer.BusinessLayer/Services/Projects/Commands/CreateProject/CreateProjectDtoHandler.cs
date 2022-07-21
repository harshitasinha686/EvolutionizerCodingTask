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
using Task = Evolutionizer.BusinessLayer.Entities.Task;

namespace Evolutionizer.BusinessLayer.Services.Projects.Commands
{
    public class CreateProjectDtoHandler : IRequestHandler<CreateProjectDto, ProjectViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CreateProjectDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProjectViewModel> Handle(CreateProjectDto request, CancellationToken cancellationToken)
        {
            var checkProgramEntity = await _repository.GetProgramById(request.ProgramId);
            if (checkProgramEntity == null) throw new EntityNotFoundException(nameof(Program), request.ProgramId);
            var entityProject = new Project(checkProgramEntity ,request.Name, request.Description);
            if (request.Tasks != null && request.Tasks.Count > 0)
            {
                var taskEntityList = new List<Task>();
                foreach (var item in request.Tasks)
                {
                    var taskEntity = new Task(entityProject, item.Name, item.Description, item.StartDate, item.EndDate);
                    taskEntityList.Add(taskEntity);
                }
                entityProject.Tasks = taskEntityList;
            }
            await _repository.AddProject(entityProject);
            var viewResult = _mapper.Map<ProjectViewModel>(entityProject);
            return viewResult;
        }
    }
}
