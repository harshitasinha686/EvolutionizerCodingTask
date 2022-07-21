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

namespace Evolutionizer.BusinessLayer.Services.Tasks.Command
{
    public class CreateTaskDtoHandler : IRequestHandler<CreateTaskDto, TaskViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CreateTaskDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TaskViewModel> Handle(CreateTaskDto request, CancellationToken cancellationToken)
        {
            var checkProjectEntity = await _repository.GetProjectById(request.ProjectId);
            if (checkProjectEntity == null) throw new EntityNotFoundException(nameof(Project), request.ProjectId);

            var entityTask = new Task(checkProjectEntity, request.Name, request.Description, request.StartDate, request.EndDate);
            await _repository.AddTask(entityTask);
            var viewResult = _mapper.Map<TaskViewModel>(entityTask);
            return viewResult;
        }
    }
}
