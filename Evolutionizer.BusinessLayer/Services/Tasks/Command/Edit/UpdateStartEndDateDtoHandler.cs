using AutoMapper;
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

namespace Evolutionizer.BusinessLayer.Services.Tasks.Command.Edit
{
    public class UpdateStartEndDateDtoHandler : IRequestHandler<UpdateStartEndDateDto, TaskViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public UpdateStartEndDateDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TaskViewModel> Handle(UpdateStartEndDateDto request, CancellationToken cancellationToken)
        {
            var taskEntity = await _repository.GetTaskById(request.Id);
            if (taskEntity == null) throw new EntityNotFoundException(nameof(BusinessLayer.Entities.Task), request.Id);
            taskEntity.UpdateTaskDates(request.StartDate, request.EndDate);
            await _repository.UpdateTask(taskEntity);
            var result = _mapper.Map<TaskViewModel>(taskEntity);
            return result;
        }
    }
}
