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

namespace Evolutionizer.BusinessLayer.Services.Projects.Queries
{
    public class GetProjectByIdDtoHandler : IRequestHandler<GetProjectByIdDto, ProjectViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public GetProjectByIdDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProjectViewModel> Handle(GetProjectByIdDto request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetProjectById(request.Id);
            if (entity == null) throw new EntityNotFoundException(nameof(Project), request.Id);
            var result = _mapper.Map<ProjectViewModel>(entity);
            return result;
        }
    }
}
