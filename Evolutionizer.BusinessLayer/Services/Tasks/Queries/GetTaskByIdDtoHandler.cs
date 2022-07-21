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

namespace Evolutionizer.BusinessLayer.Services.Tasks.Queries
{
    public class GetTaskByIdDtoHandler : IRequestHandler<GetTaskByIdDto, TaskViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public GetTaskByIdDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TaskViewModel> Handle(GetTaskByIdDto request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetTaskById(request.Id);
            if (entity == null) throw new EntityNotFoundException(nameof(BusinessLayer.Entities.Task), request.Id);
            var result = _mapper.Map<TaskViewModel>(entity);
            return result;
        }
    }
}
