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

namespace Evolutionizer.BusinessLayer.Services.Projects.Commands.Edit
{
    public class UpdateProjectDtoHandler : IRequestHandler<UpdateProjectDto, ProjectViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public UpdateProjectDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProjectViewModel> Handle(UpdateProjectDto request, CancellationToken cancellationToken)
        {
            var projectEntity = await _repository.GetProjectById(request.Id);
            if (projectEntity == null) throw new EntityNotFoundException(nameof(Project), request.Id);
            projectEntity.UpdateProject(request.Name, request.Description);
            await _repository.UpdateProject(projectEntity);
            var result = _mapper.Map<ProjectViewModel>(projectEntity);
            return result;
        }
    }
}
